using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Contracts.WeeklyOrders;
using GreenProject.Backend.Core.EntitiesExtensions;
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
                .ActiveUsers()
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
                .Where(o => o.OrderState != OrderState.Canceled)
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

            Order order = await this.FindUnlockedSubscriptionOrder(userId, q => q
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                .Include(o => o.Address)
                    .ThenInclude(a => a.Zone));

            await updateAction(order);

            this.pricing.AssignPricesToOrder(order);

            await this.Data.SaveChangesAsync();
        }

        public async Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoDto.Input deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .Include(u => u.Addresses)
                    .ThenInclude(a => a.Zone));

            if (user.IsSubscribed)
            {
                throw new AlreadySubscribedException();
            }
            user.IsSubscribed = true;

            Address address = user.Addresses
                .SingleOptional(a => a.AddressId == deliveryInfo.AddressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(deliveryInfo.AddressId));

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

            this.Notifications.UserSubscribed(user).FireAndForget();

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

            this.Notifications.UserUnsubscribed(user).FireAndForget();
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
                Crate crate = await this.Data
                    .Crates
                    .Where(c => c.ItemId == crateId)
                    .SingleOptionalAsync()
                    .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(crateId)));

                order.Details.Add(new OrderDetail
                {
                    Item = crate,
                    Quantity = 1,
                    Price = crate.Price,
                    RemainingSlots = crate.Capacity
                });
            });
        }

        public Task AddExtraProduct(int userId, QuantifiedProductDto.Input product)
        {
            return this.UpdateDetailsForWeeklyOrder(userId, async order =>
            {
                Product productEntity = await this.Data
                    .Products
                    .Where(c => c.ItemId == product.ProductId)
                    .SingleOptionalAsync()
                    .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(product.ProductId)));

                order.Details
                    .SingleOptional(d => d.ItemId == product.ProductId)
                    .IfPresent(d => d.Quantity += product.Quantity)
                    .IfAbsent(() => order.Details.Add(new OrderDetail
                    {
                        Item = productEntity,
                        Quantity = product.Quantity,
                        Price = productEntity.Price
                    }));
            });
        }

        public Task UpdateExtraProduct(int userId, QuantifiedProductDto.Input product)
        {
            return this.UpdateDetailsForWeeklyOrder(userId, order =>
            {
                order.Details
                    .Where(d => d.Item is Product)
                    .SingleOptional(d => d.ItemId == product.ProductId)
                    .IfPresent(d => d.Quantity = product.Quantity)
                    .OrElseThrow(() => NotFoundException.PurchasableItemWithId(product.ProductId));

                return Task.CompletedTask;
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

        public Task AddProductToCrate(int userId, int orderDetailId, QuantifiedProductDto.Input insertion)
        {
            return this.UpdateCrateSubProduct(userId, orderDetailId, detail =>
            {
                detail.AddSubProduct(insertion.ProductId, insertion.Quantity);
            });
        }

        public Task RemoveProductFromCrate(int userId, int orderDetailId, int productId)
        {
            return this.UpdateCrateSubProduct(userId, orderDetailId, detail =>
            {
                detail.DeleteSubProduct(productId);
            });
        }

        public Task UpdateProductInCrate(int userId, int orderDetailId, QuantifiedProductDto.Input update)
        {
            return this.UpdateCrateSubProduct(userId, orderDetailId, detail =>
            {
                detail.UpdateSubProductQuantity(update.ProductId, update.Quantity);
            });
        }

        private async Task UpdateCrateSubProduct(int userId, int orderDetailId, Action<OrderDetail> detailAction)
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
                .Include(d => d.Item)
                    .ThenInclude(d => ((Crate)d).Compatibilities)
                        .ThenInclude(c => c.Product)
                .Include(d => d.SubProducts)
                .SingleOptionalAsync(d => d.OrderDetailId == orderDetailId)
                .Map(d => d.OrElseThrow(() => NotFoundException.OrderDetailWithId(orderDetailId)));

            if (detail.OrderId != orderId)
            {
                throw NotFoundException.OrderDetailWithId(orderDetailId);
            }

            detailAction(detail);

            await this.Data.SaveChangesAsync();
        }

        public async Task SkipWeeks(int userId, int weeks)
        {
            await this.RequireSubscription(userId);

            Order order = await this.FindUnlockedSubscriptionOrder(userId);

            order.DeliveryDate += TimeSpan.FromDays(7 * weeks);
            order.WasReminded = false;

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateDeliveryInfo(int userId, DeliveryInfoDto.Input deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
               .Include(u => u.Addresses)
                    .ThenInclude(a => a.Zone));

            if (!user.IsSubscribed)
            {
                throw new NotSubscribedException();
            }

            Address address = user
                .Addresses
                .SingleOptional(a => a.AddressId == deliveryInfo.AddressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(deliveryInfo.AddressId));

            Order order = await this.FindUnlockedSubscriptionOrder(userId, q => q
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item));

            order.DeliveryDate = await this.scheduler.FindNextAvailableDate(order.DeliveryDate, address.ZipCode);
            order.Address = address;
            order.Notes = deliveryInfo.Notes;

            this.pricing.AssignPricesToOrder(order);

            await this.Data.SaveChangesAsync();
        }
    }
}
