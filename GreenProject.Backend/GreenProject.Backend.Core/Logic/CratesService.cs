using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class CratesService : AbstractItemsService<Crate>, ICratesService
    {
        private const int CRATE_CATEGORY_ID = 1;

        public CratesService(IRequestSession request)
            : base(request)
        {
        }

        public Task<PagedCollection<CrateOutputDto>> GetCrates(PaginationFilter pagination, PurchasableFilters filters)
        {
            return this.GetPaged<CrateOutputDto>(pagination, filters);
        }

        public Task<CrateOutputDto> InsertCrate(CrateInputDto crate)
        {
            return this.Insert<CrateOutputDto>(crateEntity =>
            {
                crateEntity.Name = crate.Name;
                crateEntity.Description = crate.Description;
                crateEntity.Capacity = crate.Capacity;
                crateEntity.CategoryId = CRATE_CATEGORY_ID;

                crateEntity.Prices.Add(new Price
                {
                    Value = crate.Price,
                    UnitName = UnitName.Piece,
                    UnitMultiplier = 1,
                    Type = CustomerType.Person
                });
            });
        }

        public Task DeleteCrate(int crateId)
        {
            return this.Delete(crateId);
        }

        public Task<CrateOutputDto> UpdateCrate(int crateId, CrateInputDto crate)
        {
            return this.Update<CrateOutputDto>(crateId, crateEntity =>
            {
                crateEntity.Name = crate.Name;
                crateEntity.Description = crate.Description;
                crateEntity.Capacity = crate.Capacity;

                crateEntity.Prices.Single().Value = crate.Price;
            });
        }

        protected override IQueryable<Crate> GetDefaultQuery()
        {
            return this.Data.Crates;
        }

        public async Task<IEnumerable<CompatibleProductOutputDto>> GetCompatibleProducts(int crateId)
        {
            return await this.Data
                .CrateCompatibilities
                .Where(c => c.CrateId == crateId)
                .ProjectTo<CompatibleProductOutputDto>(this.Mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
