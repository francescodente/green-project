using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Orders.States;
using GreenProject.Backend.Contracts.Pagination;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IOrdersService
    {
        Task<PagedCollection<CustomerOrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination);

        Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(OrderFilters filters, PaginationFilter pagination);

        Task ChangeOrderState(int orderId, OrderStateDto newState);
    }
}
