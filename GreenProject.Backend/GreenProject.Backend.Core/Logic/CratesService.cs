using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
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

                this.SetCrateCompatibleProducts(crateEntity, crate);
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

                this.SetCrateCompatibleProducts(crateEntity, crate);
            });
        }

        private void SetCrateCompatibleProducts(Crate crateEntity, CrateInputDto crate)
        {
            crateEntity.Compatibilities.Clear();
            crate.CompatibleProducts.Select(p => new CrateCompatibility
            {
                ProductId = p.ProductId,
                Maximum = p.Maximum,
                Multiplier = p.Multiplier
            })
            .ForEach(crateEntity.Compatibilities.Add);
        }

        protected override IQueryable<Crate> GetDefaultQuery()
        {
            return this.Data.Crates;
        }
    }
}
