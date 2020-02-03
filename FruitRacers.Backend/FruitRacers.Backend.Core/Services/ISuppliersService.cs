using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Contracts.Suppliers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ISuppliersService
    {
        Task<PagedCollection<SupplierInfoDto>> GetAllSuppliers(PaginationFilter pagination);
    }
}
