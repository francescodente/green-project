using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class OrdersService : AbstractService, IOrdersService
    {
        private readonly IPriceCalculator pricing;

        public OrdersService(IRequestSession request, IPriceCalculator pricing)
            : base(request)
        {
            this.pricing = pricing;
        }

        private IOrderRepository FilteredOrders(OrderFilters filters)
        {
            IOrderRepository repository = this.Data
                .Orders
                .IncludingSections();

            filters.FromDate.AsOptional().IfPresent(d => repository = repository.AfterDate(d));
            filters.ToDate.AsOptional().IfPresent(d => repository = repository.BeforeDate(d));

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

            return repository.WithStates(states.ToArray());
        }

        private CustomerOrderDto MapToCustomerOrderDto(Order order)
        {
            CustomerOrderDto orderOutput = this.Mapper.Map<CustomerOrderDto>(order);
            Enumerable.Zip(order.Sections, orderOutput.Sections).ForEach(s =>
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

        public async Task<PagedCollection<CustomerOrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination)
        {
            IOrderRepository orders = this.FilteredOrders(filters)
                .BelongingTo(customerId)
                .OrderBy(o => o.Timestamp);
            return await ServiceUtils.PagedCollectionFromRepository(orders, pagination, this.MapToCustomerOrderDto);
        }

        public async Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(int supplierId, OrderFilters filters, PaginationFilter pagination)
        {
            IOrderRepository orders = this.FilteredOrders(filters)
                .DirectedTo(supplierId)
                .OrderBy(o => o.DeliveryDate);
            return await ServiceUtils.PagedCollectionFromRepository(orders, pagination, o => this.MapToSupplierOrderDto(o, supplierId));
        }
    }
}
