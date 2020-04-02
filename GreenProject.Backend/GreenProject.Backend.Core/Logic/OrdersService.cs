using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Orders.States;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Core.Entities;
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
        public OrdersService(IRequestSession request)
            : base(request)
        {

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

        public Task ChangeOrderState(int orderId, OrderStateDto orderState)
        {
            throw new NotImplementedException();
        }
    }
}
