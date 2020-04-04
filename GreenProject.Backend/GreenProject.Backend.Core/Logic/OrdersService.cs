using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Orders.States;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
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
            }
        }

        public Task<PagedCollection<CustomerOrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination)
        {
            IEnumerable<OrderState> states = this.GetRequestedStates(filters);
            return this.Data
                .Orders
                .IncludingDeliveryInfo()
                .Where(o => states.Contains(o.OrderState))
                .Where(o => o.UserId == customerId)
                .OrderBy(o => o.Timestamp)
                .ToPagedCollection(pagination, this.Mapper.Map<CustomerOrderDto>);
        }

        public Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(OrderFilters filters, PaginationFilter pagination)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeOrderState(int orderId, OrderStateDto newState)
        {
            Order order = await this.Data
                .Orders
                .Include(o => o.User)
                .SingleOptionalAsync(o => o.OrderId == orderId)
                .Map(o => o.OrElseThrow(() => NotFoundException.OrderWithId(orderId)));

            OrderState targetState = (OrderState)newState;
            OrderState oldState = order.OrderState;

            order.ChangeState(targetState);

            if (order.IsSubscription && (targetState == OrderState.Canceled || targetState == OrderState.Completed))
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
                Quantity = bookedCrate.Quantity
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
