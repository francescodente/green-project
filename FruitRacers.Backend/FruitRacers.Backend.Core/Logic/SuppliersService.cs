using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Contracts.Suppliers;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.Core.Logic
{
    public class SuppliersService : AbstractService, ISuppliersService
    {
        public SuppliersService(IRequestSession request)
            : base(request)
        {
        }

        public async Task<PagedCollection<SupplierInfoDto>> GetAllSuppliers(PaginationFilter pagination)
        {
            IQueryable<Supplier> suppliers = this.Data
                .Suppliers
                .Include(s => s.LogoImage)
                .Include(s => s.BackgroundImage)
                .Include(s => s.User)
                    .ThenInclude(s => s.Addresses);
            return await suppliers.ToPagedCollection(pagination, this.Mapper.Map<SupplierInfoDto>);
        }
    }
}
