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
        Task<IEnumerable<CompatibilityDto.Output>> GetCompatibleProducts(int crateId);

        Task<PagedCollection<CrateDto.Output>> GetCrates(PaginationFilter pagination, PurchasableFilters filters);

        Task<CrateDto.Output> InsertCrate(CrateDto.Input crate);

        Task<CrateDto.Output> UpdateCrate(int crateId, CrateDto.Input crate);

        Task DeleteCrate(int crateId);
    }
}
