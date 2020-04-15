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
            User user = await this.RequireUserById(userId);

            user.BookedCrates.Add(new BookedCrate
            {
                CrateId = crateId
            });

            if (user.IsSubscribed)
            {
                Order order = await this.FilterFirstSubscriptionOrder(userId).FirstAsync();
                order.Details.Add(new OrderDetail
                {
                    ItemId = crateId,
                    Quantity = 1
                });
            }

            await this.Data.SaveChangesAsync();
        }

        public Task AddProductToCrate(int userId, int bookedCrateId, CartItemInputDto insertion)
        {
            throw new NotImplementedException();
        }

        public async Task<WeeklyOrderDto> GetWeeklyOrderData(int userId)
        {
            bool isSubscribed = await this.IsSubscribed(userId);

            if (isSubscribed)
            {
                return await this.FilterFirstSubscriptionOrder(userId)
                    .ProjectTo<WeeklyOrderDto>(this.Mapper.ConfigurationProvider)
                    .SingleAsync();
            }
            else
            {
                return await this.Data
                    .Users
                    .Where(u => u.UserId == userId)
                    .ProjectTo<WeeklyOrderDto>(this.Mapper.ConfigurationProvider)
                    .SingleAsync();
            }
        }

        public Task RemoveCrate(int userId, int crateId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromCrate(int userId, int bookedCrateId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            throw new NotImplementedException();
        }

        public Task Unsubscribe(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductInCrate(int userId, int bookedCrateId, CartItemInputDto update)
        {
            throw new NotImplementedException();
        }
    }
}
