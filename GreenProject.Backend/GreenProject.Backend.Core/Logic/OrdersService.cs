using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Pagination;
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

namespace GreenProject.Backend.Core.Logic
{
    public class OrdersService : AbstractService, IOrdersService
    {
        private readonly IOrderScheduler _scheduler;
        private readonly IPricingService _pricing;
        private readonly OrdersSettings _settings;

        public OrdersService(IRequestSession request, IOrderScheduler scheduler, IPricingService pricing, OrdersSettings settings)
            : base(request)
        {
            _scheduler = scheduler;
            _pricing = pricing;
            _settings = settings;
        }

        public Task<PagedCollection<OrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination)
        {
            return GetOrdersFilteredBy(filters)
                .Where(o => o.UserId == customerId)
                .OrderByDescending(o => o.Timestamp)
                .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
                .ToPagedCollection(pagination);
        }

        public Task<PagedCollection<OrderDto>> GetSupplierOrders(OrderFilters filters, PaginationFilter pagination)
        {
            return GetOrdersFilteredBy(filters)
                .OrderBy(o => o.DeliveryDate)
                .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
                .ToPagedCollection(pagination);
        }

        private IQueryable<Order> GetOrdersFilteredBy(OrderFilters filters)
        {
            IQueryable<Order> query = Data.Orders;

            if (filters.States != null)
            {
                query = query.Where(o => filters.States.Contains(o.OrderState));
            }

            if (filters.From.HasValue)
            {
                query = query.Where(o => o.DeliveryDate >= filters.From.Value);
            }

            if (filters.To.HasValue)
            {
                query = query.Where(o => o.DeliveryDate <= filters.To.Value);
            }

            if (filters.ZipCodes != null)
            {
                query = query.Where(o => filters.ZipCodes.Contains(o.Address.ZipCode));
            }

            return query;
        }

        public async Task ChangeOrderState(int orderId, ChangeOrderStateDto request)
        {
            Order order = await Data
                .Orders
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                .Include(o => o.Address)
                    .ThenInclude(a => a.Zone)
                .Include(o => o.User)
                .SingleOptionalAsync(o => o.OrderId == orderId)
                .Map(o => o.OrElseThrow(() => NotFoundException.OrderWithId(orderId)));

            OrderState oldState = order.OrderState;

            order.ChangeState(request.NewState);

            if (order.IsSubscription && (request.NewState == OrderState.Canceled || request.NewState == OrderState.Completed))
            {
                await RenewWeeklyOrder(order);
            }

            await Data.SaveChangesAsync();

            Notifications.OrderStateChanged(order, oldState).FireAndForget();
        }

        private async Task RenewWeeklyOrder(Order order)
        {
            Address address = await Data
                .Addresses
                .Where(a => a.UserId == order.UserId)
                .Where(a => a.User.DefaultAddressId == a.AddressId)
                .Include(a => a.Zone)
                .SingleAsync();

            DateTime scheduleDate = await _scheduler.FindNextAvailableDate(
                order.DeliveryDate.AddDays(_settings.WeeklyOrderRenewTimeInDays),
                address.ZipCode);

            var newOrder = new Order
            {
                UserId = order.UserId,
                DeliveryDate = scheduleDate,
                Address = address,
                Timestamp = DateTime.Now,
                OrderState = OrderState.Pending,
                IsSubscription = true
            };

            newOrder
                .Details
                .Where(d => d.Item is Crate)
                .Where(d => d.Item.IsEnabled && !d.Item.IsDeleted)
                .Select(d => d.CreateCopy())
                .ForEach(newOrder.Details.Add);

            _pricing.AssignPricesToOrder(newOrder);

            Data.Orders.Add(newOrder);
        }
    }
}
