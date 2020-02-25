using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Pagination;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IOrdersService
    {
        Task<PagedCollection<CustomerOrderDto>> GetCustomerOrders(int customerId, OrderFilters filters, PaginationFilter pagination);

        Task<PagedCollection<SupplierOrderDto>> GetSupplierOrders(int supplierId, OrderFilters filters, PaginationFilter pagination);
    }
}
