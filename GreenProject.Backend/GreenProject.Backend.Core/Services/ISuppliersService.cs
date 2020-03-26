using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.Suppliers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ISuppliersService
    {
        Task<PagedCollection<SupplierInfoDto>> GetAllSuppliers(PaginationFilter pagination);
    }
}
