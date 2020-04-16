using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.WeeklyOrders;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class WeeklyOrdersService : AbstractService, IWeeklyOrdersService
    {
        public WeeklyOrdersService(IRequestSession request) : base(request)
        {
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
                .Where(o => o.OrderState == OrderState.Pending)
                .Where(o => o.IsSubscription)
                .OrderByDescending(o => o.DeliveryDate)
                .Take(1);
        }

        public async Task AddCrate(int userId, int crateId)
        {
            await this.RequireSubscription(userId);
            
            Order order = await this.FilterFirstSubscriptionOrder(userId).FirstAsync();
            order.Details.Add(new OrderDetail
            {
                ItemId = crateId,
                Quantity = 1
            });

            await this.Data.SaveChangesAsync();
        }

        public async Task AddProductToCrate(int userId, int bookedCrateId, CartItemInputDto insertion)
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

        public async Task RemoveProductFromCrate(int userId, int bookedCrateId, int productId)
        {
            await this.RequireSubscription(userId);
        }

        public Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            throw new NotImplementedException();
        }

        public async Task Unsubscribe(int userId)
        {
            await this.RequireSubscription(userId);
        }

        public async Task UpdateProductInCrate(int userId, int bookedCrateId, CartItemInputDto update)
        {
            await this.RequireSubscription(userId);
        }
    }
}
