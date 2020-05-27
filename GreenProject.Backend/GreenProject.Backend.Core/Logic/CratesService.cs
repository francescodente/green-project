using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class CratesService : AbstractItemsService<Crate>, ICratesService
    {
        private const int CrateCategoryId = 1;

        public CratesService(IRequestSession request)
            : base(request)
        {
        }

        public Task<PagedCollection<CrateDto.Output>> GetCrates(PaginationFilter pagination, PurchasableFilters filters)
        {
            return GetPaged<CrateDto.Output>(pagination, filters);
        }

        public Task<CrateDto.Output> InsertCrate(CrateDto.Input crate)
        {
            return Insert<CrateDto.Output>(crateEntity =>
            {
                crateEntity.Name = crate.Name;
                crateEntity.Description = crate.Description;
                crateEntity.Capacity = crate.Capacity;
                crateEntity.CategoryId = CrateCategoryId;
                crateEntity.IsStarred = crate.IsStarred;
                crateEntity.Price = crate.Price;
                crateEntity.IvaPercentage = crate.IvaPercentage;
            });
        }

        public Task DeleteCrate(int crateId)
        {
            return Delete(crateId);
        }

        public Task<CrateDto.Output> UpdateCrate(int crateId, CrateDto.Input crate)
        {
            return Update<CrateDto.Output>(crateId, crateEntity =>
            {
                crateEntity.Name = crate.Name;
                crateEntity.Description = crate.Description;
                crateEntity.Capacity = crate.Capacity;
                crateEntity.Price = crate.Price;
                crateEntity.IvaPercentage = crate.IvaPercentage;
                crateEntity.IsStarred = crate.IsStarred;
            });
        }

        protected override IQueryable<Crate> GetDefaultQuery()
        {
            return Data.ActiveCrates();
        }

        public async Task<IEnumerable<CompatibilityDto.OutputWithProduct>> GetCompatibleProducts(int crateId)
        {
            return await Data
                .CrateCompatibilities
                .Where(c => c.CrateId == crateId)
                .ProjectTo<CompatibilityDto.OutputWithProduct>(Mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
