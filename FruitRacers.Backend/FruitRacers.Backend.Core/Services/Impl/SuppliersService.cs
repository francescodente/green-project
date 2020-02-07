﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Contracts.Suppliers;
using FruitRacers.Backend.Core.Entities;
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

        public async Task<PagedCollection<SupplierInfoDto>> GetAllSuppliers(PaginationFilter pagination)
        {
            return await ServiceUtils.PagedCollectionFromRepository<Supplier, SupplierInfoDto>(this.Data.Suppliers, pagination, this.Mapper);
        }
    }
}
