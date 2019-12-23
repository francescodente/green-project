using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.Suppliers;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class SuppliersService : AbstractService, ISuppliersService
    {
        public SuppliersService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {
        }

        public async Task<IEnumerable<SupplierInfoDto>> GetAllSuppliers()
        {
            // TODO: Select correct suppliers
            return await this.Session
                .Users
                .GetAll()
                .Then(s => s.Select(this.Mapper.Map<SupplierInfoDto>));
        }
    }
}
