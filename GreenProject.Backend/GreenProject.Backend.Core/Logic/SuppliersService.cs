using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.Suppliers;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.Core.Logic
{
    public class SuppliersService : AbstractService, ISuppliersService
    {
        public SuppliersService(IRequestSession request)
            : base(request)
        {
        }

        public Task<PagedCollection<SupplierInfoDto>> GetAllSuppliers(PaginationFilter pagination)
        {
            IQueryable<Supplier> suppliers = this.Data
                .Suppliers
                .Include(s => s.LogoImage)
                .Include(s => s.BackgroundImage)
                .Include(s => s.User)
                    .ThenInclude(s => s.Addresses);
            return suppliers.ToPagedCollection(pagination, this.Mapper.Map<SupplierInfoDto>);
        }
    }
}
