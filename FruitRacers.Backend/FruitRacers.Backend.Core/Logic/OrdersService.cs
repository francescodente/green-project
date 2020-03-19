using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
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

        private IQueryable<Order> FilteredOrders(OrderFilters filters)
        {
            IQueryable<Order> orders = this.Data
                .Orders
                .IncludingDeliveryInfo()
                .IncludingSections();

            filters.FromDate.AsOptional().IfPresent(d => orders = orders.Where(o => o.DeliveryDate >= d));
            filters.ToDate.AsOptional().IfPresent(d => orders = orders.Where(o => o.DeliveryDate <= d));

            IList<OrderState> states = new List<OrderState>();
            if (filters.IncludeCanceled)
            {
                states.Add(OrderState.Canceled);
            }
            if (!filters.IgnoreCompleted)
            {
                states.Add(OrderState.Completed);
            }
            if (!filters.IgnorePending)
            {
                states.Add(OrderState.Pending);
            }

            return orders.Where(o => states.Contains(o.OrderState));
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

        private SupplierOrderDto MapToSupplierOrderDto(Order order, int supplierId)
        {
            SupplierOrderDto orderOutput = this.Mapper.Map<SupplierOrderDto>(order);
            OrderSection section = order.Sections.Single(s => s.SupplierId == supplierId);
            orderOutput.Details = this.Mapper.Map<OrderSectionDto>(section);
            return orderOutput;
        }

        public Task<PagedCollection<CustomerOrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination)
        {
            IQueryable<Order> orders = this.FilteredOrders(filters)
                .Where(o => o.UserId == customerId)
                .OrderBy(o => o.Timestamp);
            return ServiceUtils.PagedCollectionFromQuery(orders, pagination, this.MapToCustomerOrderDto);
        }

        public Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(int supplierId, OrderFilters filters, PaginationFilter pagination)
        {
            IQueryable<Order> orders = this.FilteredOrders(filters);
            return ServiceUtils.PagedCollectionFromQuery(orders, pagination, o => this.MapToSupplierOrderDto(o, supplierId));
        }
    }
}
