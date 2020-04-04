using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICratesService
    {
        Task<PagedCollection<CrateOutputDto>> GetCrates(PaginationFilter pagination, PurchasableFilters filters);

        Task<CrateOutputDto> InsertCrate(CrateInputDto crate);

        Task<CrateOutputDto> UpdateCrate(int crateId, CrateInputDto crate);

        Task DeleteCrate(int crateId);
    }
}
