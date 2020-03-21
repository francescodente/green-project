using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
{
    public class OrdersService : AbstractService, IOrdersService
    {
        private readonly IPriceCalculator pricing;

        public OrdersService(IRequestSession request, IPriceCalculator pricing)
            : base(request)
        {
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
                .IncludingSections()
                .Where(o => states.Contains(o.OrderState))
                .Where(o => o.UserId == customerId)
                .OrderBy(o => o.Timestamp)
                .ToPagedCollection(pagination, this.MapToCustomerOrderDto);
        }

        private CustomerOrderDto MapToCustomerOrderDto(Order order)
        {
            CustomerOrderDto orderOutput = this.Mapper.Map<CustomerOrderDto>(order);
            order.Sections.Zip(orderOutput.Sections).ForEach(s =>
            {
                s.Second.Prices = this.pricing.Calculate(s.First);
            });
            return orderOutput;
        }

        public Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(int supplierId, OrderFilters filters, PaginationFilter pagination)
        {
            IEnumerable<OrderState> states = this.GetRequestedStates(filters);
            return this.Data
                .OrderSections
                .IncludingDeliveryInfo()
                .Include(s => s.Details)
                    .ThenInclude(d => d.Product)
                .Include(s => s.Order)
                    .ThenInclude(o => o.User)
                .Where(s => s.SupplierId == supplierId)
                .Where(s => states.Contains(s.Order.OrderState))
                .ToPagedCollection(pagination, this.MapToSupplierOrderDto);
        }

        private SupplierOrderDto MapToSupplierOrderDto(OrderSection order)
        {
            SupplierOrderDto orderOutput = this.Mapper.Map<SupplierOrderDto>(order);
            orderOutput.Prices = this.pricing.Calculate(order);
            return orderOutput;
        }
    }
}
