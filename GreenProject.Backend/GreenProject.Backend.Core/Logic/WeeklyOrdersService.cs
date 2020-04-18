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

        public async Task AddCrate(int userId, int crateId)
        {
            await this.RequireSubscription(userId);
            
            Order order = await this.FilterFirstSubscriptionOrder(userId).SingleAsync();
            order.Details.Add(new OrderDetail
            {
                ItemId = crateId,
                Quantity = 1
            });

            this.pricing.AssignPricesToOrder(order);

            await this.Data.SaveChangesAsync();
        }

        public async Task AddProductToCrate(int userId, int orderDetailId, QuantifiedProductInputDto insertion)
        {
            await this.RequireSubscription(userId);
        }

        public async Task<WeeklyOrderDto> GetWeeklyOrderData(int userId)
        {
            await this.RequireSubscription(userId);

            return await this.FilterFirstSubscriptionOrder(userId)
                .ProjectTo<WeeklyOrderDto>(this.Mapper.ConfigurationProvider)
                .SingleAsync();
        }

        public async Task RemoveCrate(int userId, int crateId)
        {
            await this.RequireSubscription(userId);
        }

        public async Task RemoveProductFromCrate(int userId, int orderDetailId, int productId)
        {
            await this.RequireSubscription(userId);
        }

        public async Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .IncludeFilter(u => u.Addresses.Where(a => a.AddressId == deliveryInfo.AddressId)));

            Address address = user.Addresses.SingleOptional().OrElseThrow(() => new UnauthorizedUserAccessException(userId));

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
                .Where(o => this.DateTime.Today.AddDays(this.settings.LockTimeSpanInDays) < o.DeliveryDate)
                .SingleOptionalAsync()
                .Then(o => o.IfPresent(order => order.OrderState = OrderState.Canceled));

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateProductInCrate(int userId, int orderDetailId, QuantifiedProductInputDto update)
        {
            await this.RequireSubscription(userId);
        }
    }
}
