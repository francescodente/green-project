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
                .SingleOptionalAsync(o => o.OrderId == orderId)
                .Map(o => o.OrElseThrow(() => NotFoundException.OrderWithId(orderId)));

            OrderState oldState = order.OrderState;

            order.ChangeState(newState);

            if (order.IsSubscription && (newState == OrderState.Canceled || newState == OrderState.Completed))
            {
                await this.RenewWeeklyOrder(order);
            }

            await this.Data.SaveChangesAsync();

            await this.Notifications.OrderStateChanged(order, oldState);
        }

        private async Task RenewWeeklyOrder(Order order)
        {
            var destinationData = await this.Data
                .Users
                .Where(u => u.UserId == order.UserId)
                .Select(u => new { AddressId = u.DefaultAddressId.Value, u.DefaultAddress.ZipCode })
                .SingleAsync();

            DateTime scheduleDate = await scheduler.FindNextAvailableDate(order.DeliveryDate.AddDays(7), destinationData.ZipCode);

            Order newOrder = new Order
            {
                UserId = order.UserId,
                DeliveryDate = scheduleDate,
                AddressId = destinationData.AddressId,
                Timestamp = this.DateTime.Now,
                OrderState = OrderState.Pending,
                IsSubscription = true
            };

            newOrder
                .Details
                .Where(d => d.Item is Crate)
                .Select(d => d.CreateCopy())
                .ForEach(newOrder.Details.Add);

            this.pricing.UpdateOrderPrices(newOrder);

            this.Data.Orders.Add(newOrder);
        }
    }
}
