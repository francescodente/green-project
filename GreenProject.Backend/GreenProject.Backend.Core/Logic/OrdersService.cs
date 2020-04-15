using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class OrdersService : AbstractService, IOrdersService
    {
        private readonly IOrderScheduler scheduler;
        private readonly IPriceCalculator pricing;

        public OrdersService(IRequestSession request, IOrderScheduler scheduler, IPriceCalculator pricing)
            : base(request)
        {
            this.scheduler = scheduler;
            this.pricing = pricing;
        }

        public Task<PagedCollection<OrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination)
        {
            IEnumerable<OrderState> states = this.GetRequestedStates(filters);
            return this.GetOrdersFilteredBy(filters)
                .Where(o => o.UserId == customerId)
                .OrderBy(o => o.Timestamp)
                .ProjectTo<OrderDto>(this.Mapper.ConfigurationProvider)
                .ToPagedCollection(pagination);
        }

        public Task<PagedCollection<OrderDto>> GetSupplierOrders(OrderFilters filters, PaginationFilter pagination)
        {
            return this.GetOrdersFilteredBy(filters)
                .OrderBy(o => o.DeliveryDate)
                .ProjectTo<OrderDto>(this.Mapper.ConfigurationProvider)
                .ToPagedCollection(pagination);
        }

        private IQueryable<Order> GetOrdersFilteredBy(OrderFilters filters)
        {
            IEnumerable<OrderState> states = this.GetRequestedStates(filters);

            IQueryable<Order> query = this.Data
                .Orders
                .Where(o => states.Contains(o.OrderState));

            return filters.DeliveryDate
                .AsOptional()
                .Map(d => query.Where(o => o.DeliveryDate == d))
                .OrElse(query);
        }

        private IEnumerable<OrderState> GetRequestedStates(OrderFilters filters)
        {
            if (filters.IncludeCanceled)
            {
                yield return OrderState.Canceled;
            }
            if (!filters.IgnoreCompleted)
            {
                yield return OrderState.Completed;
            }
            if (!filters.IgnorePending)
            {
                yield return OrderState.Pending;
                yield return OrderState.Shipping;
            }
        }

        public async Task ChangeOrderState(int orderId, OrderState newState)
        {
            Order order = await this.Data
                .Orders
                .Include(o => o.User)
                .SingleOptionalAsync(o => o.OrderId == orderId)
                .Map(o => o.OrElseThrow(() => NotFoundException.OrderWithId(orderId)));

            OrderState oldState = order.OrderState;

            order.ChangeState(newState);

            if (order.IsSubscription && (newState == OrderState.Canceled || newState == OrderState.Completed))
            {
                await this.RenewWeeklyOrder(order.User, order.DeliveryDate);
            }

            await this.Data.SaveChangesAsync();

            await this.Notifications.OrderStateChanged(order, oldState);
        }

        private async Task RenewWeeklyOrder(User user, DateTime currentDate)
        {
            IEnumerable<BookedCrate> bookedCrates = await this.Data
                .BookedCrates
                .Where(c => c.UserId == user.UserId)
                .Include(c => c.Crate)
                .Include(c => c.Compositions)
                .ToListAsync();

            Order order = new Order
            {
                DeliveryDate = await scheduler.FindNextAvailableDateForAddressId(this.Data, user.DefaultAddressId.Value, currentDate.AddDays(7)),
                AddressId = user.DefaultAddressId.Value,
                Timestamp = this.DateTime.Now,
                OrderState = OrderState.Pending,
                IsSubscription = true
            };

            bookedCrates
                .Select(this.CreateDetailFromBookedCrate)
                .ForEach(order.Details.Add);

            this.pricing.UpdateOrderPrices(order);

            user.Orders.Add(order);
        }

        private OrderDetail CreateDetailFromBookedCrate(BookedCrate bookedCrate)
        {
            OrderDetail detail = new OrderDetail
            {
                ItemId = bookedCrate.CrateId,
                Price = bookedCrate.Crate.Prices.Single().Value,
                Quantity = 1
            };

            bookedCrate.Compositions.Select(c => new OrderDetailSubProduct
            {
                ProductId = c.ProductId,
                Quantity = c.Quantity
            })
                .ForEach(detail.SubProducts.Add);

            return detail;
        }
    }
}
