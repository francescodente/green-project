using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.WeeklyOrders;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace GreenProject.Backend.Core.Logic
{
    public class WeeklyOrdersService : AbstractService, IWeeklyOrdersService
    {
        private readonly IPricingService pricing;
        private readonly IOrderScheduler scheduler;
        private readonly OrdersSettings settings;

        public WeeklyOrdersService(IRequestSession request, IPricingService pricing, IOrderScheduler scheduler, OrdersSettings settings)
            : base(request)
        {
            this.pricing = pricing;
            this.scheduler = scheduler;
            this.settings = settings;
        }

        private Task<bool> IsSubscribed(int userId)
        {
            return this.Data
                .Users
                .Where(u => u.UserId == userId)
                .Select(u => new { u.IsSubscribed })
                .SingleOptionalAsync()
                .Map(s => s.OrElseThrow(() => NotFoundException.UserWithId(userId)).IsSubscribed);
        }

        private async Task RequireSubscription(int userId)
        {
            if (!await this.IsSubscribed(userId))
            {
                throw new NotSubscribedException();
            }
        }

        private IQueryable<Order> FilterFirstSubscriptionOrder(int userId)
        {
            return this.Data
                .Orders
                .Where(o => o.UserId == userId)
                .Where(o => o.IsSubscription)
                .OrderByDescending(o => o.DeliveryDate)
                .Take(1);
        }

        private Task<Order> FindUnlockedSubscriptionOrder(int userId, QueryWrapper<Order> wrapper = null)
        {
            return this.FilterFirstSubscriptionOrder(userId)
                .UnlockedOnly(this.DateTime, this.settings)
                .WrapIfPresent(wrapper)
                .SingleOptionalAsync()
                .Map(o => o.OrElseThrow(() => new OrderLockedException()));
        }

        private async Task UpdateDetailsForWeeklyOrder(int userId, Func<Order, Task> updateAction)
        {
            await this.RequireSubscription(userId);

            Order order = await this.FindUnlockedSubscriptionOrder(userId, q => q.Include(o => o.Details));

            await updateAction(order);

            this.pricing.AssignPricesToOrder(order);

            await this.Data.SaveChangesAsync();
        }

        public async Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .IncludeFilter(u => u.Addresses.Where(a => a.AddressId == deliveryInfo.AddressId)));

            Address address = user.Addresses.SingleOptional().OrElseThrow(() => new UnauthorizedUserAccessException());

            if (user.IsSubscribed)
            {
                throw new AlreadySubscribedException();
            }
            user.IsSubscribed = true;

            Order order = new Order
            {
                UserId = userId,
                Address = address,
                DeliveryDate = await this.scheduler.FindNextAvailableDate(this.DateTime.Today.AddDays(1), address.ZipCode),
                IsSubscription = true,
                Timestamp = this.DateTime.Now,
                OrderState = OrderState.Pending,
                Notes = deliveryInfo.Notes
            };
            this.pricing.AssignPricesToOrder(order);

            this.Data.Orders.Add(order);
            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<WeeklyOrderDto>(order);
        }

        public async Task Unsubscribe(int userId)
        {
            User user = await this.RequireUserById(userId);

            if (!user.IsSubscribed)
            {
                throw new NotSubscribedException();
            }

            user.IsSubscribed = false;

            await this.FilterFirstSubscriptionOrder(userId)
                .UnlockedOnly(this.DateTime, this.settings)
                .SingleOptionalAsync()
                .Then(o => o.IfPresent(order => order.OrderState = OrderState.Canceled));

            await this.Data.SaveChangesAsync();
        }

        public async Task<WeeklyOrderDto> GetWeeklyOrderData(int userId)
        {
            await this.RequireSubscription(userId);

            return await this.FilterFirstSubscriptionOrder(userId)
                .ProjectTo<WeeklyOrderDto>(this.Mapper.ConfigurationProvider)
                .SingleAsync();
        }

        public Task AddCrate(int userId, int crateId)
        {
            return this.UpdateDetailsForWeeklyOrder(userId, async order =>
            {
                var crateData = await this.Data
                    .Crates
                    .Where(c => c.ItemId == crateId)
                    .Select(c => new { Price = c.Prices.Single().Value, c.Capacity })
                    .SingleOptionalAsync()
                    .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(crateId)));

                order.Details.Add(new OrderDetail
                {
                    ItemId = crateId,
                    Quantity = 1,
                    Price = crateData.Price,
                    RemainingSlots = crateData.Capacity
                });
            });
        }

        public Task RemoveItem(int userId, int orderDetailId)
        {
            return this.UpdateDetailsForWeeklyOrder(userId, order =>
            {
                OrderDetail detail = order.Details
                    .SingleOptional(d => d.OrderDetailId == orderDetailId)
                    .OrElseThrow(() => NotFoundException.OrderDetailWithId(orderDetailId));

                order.Details.Remove(detail);

                return Task.CompletedTask;
            });
        }

        public async Task AddProductToCrate(int userId, int orderDetailId, QuantifiedProductInputDto insertion)
        {
            await this.RequireSubscription(userId);

            int orderId = await this.FilterFirstSubscriptionOrder(userId)
                .UnlockedOnly(this.DateTime, this.settings)
                .Select(o => new { o.OrderId })
                .SingleOptionalAsync()
                .Map(o => o.OrElseThrow(() => new OrderLockedException()).OrderId);

            OrderDetail detail = await this.Data
                .OrderDetails
                .Where(d => d.Item is Crate)
                .SingleOptionalAsync(d => d.OrderDetailId == orderDetailId)
                .Map(d => d.OrElseThrow(() => NotFoundException.OrderDetailWithId(orderDetailId)));

            if (detail.OrderId != orderId)
            {
                throw new UnauthorizedUserAccessException();
            }

            CrateCompatibility compatibility = await this.Data
                .CrateCompatibilities
                .SingleOptionalAsync(c => c.CrateId == detail.ItemId && c.ProductId == insertion.ProductId)
                .Map(c => c.OrElseThrow(() => new IncompatibleProductException()));

            int actualQuantity = compatibility.Multiplier * insertion.Quantity;

            if (actualQuantity > detail.RemainingSlots || insertion.Quantity > compatibility.Maximum.GetValueOrDefault(int.MaxValue))
            {
                throw new InvalidQuantityException();
            }

            detail.SubProducts.Add(new OrderDetailSubProduct
            {
                ProductId = insertion.ProductId,
                Quantity = insertion.Quantity
            });
            detail.RemainingSlots -= insertion.Quantity * compatibility.Multiplier;

            await this.Data.SaveChangesAsync();
        }

        public async Task RemoveProductFromCrate(int userId, int orderDetailId, int productId)
        {
            await this.RequireSubscription(userId);
        }

        public async Task UpdateProductInCrate(int userId, int orderDetailId, int quantity)
        {
            await this.RequireSubscription(userId);
        }
    }
}
