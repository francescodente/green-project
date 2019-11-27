using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class SuppliersService : AbstractService, ISuppliersService
    {
        public SuppliersService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {
        }

        public async Task<IEnumerable<SupplierDto>> GetAllSuppliers()
        {
            return await this.Session
                .Suppliers
                .GetAll()
                .Then(s => s.Select(this.Mapper.Map<SupplierDto>));
        }
    }
}
