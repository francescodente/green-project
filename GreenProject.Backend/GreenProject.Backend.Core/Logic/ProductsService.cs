using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;

namespace GreenProject.Backend.Core.Logic
{
    public class ProductsService : AbstractItemsService<Product>, IProductsService
    {
        public ProductsService(IRequestSession request)
            : base(request)
        {
        }

        public Task<PagedCollection<ProductOutputDto>> GetProducts(PaginationFilter pagination, PurchasableFilters filters)
        {
            return this.GetPaged<ProductOutputDto>(pagination, filters);
        }

        public Task DeleteProduct(int productId)
        {
            return this.Delete(productId);
        }

        public Task<ProductOutputDto> InsertProduct(ProductInputDto product)
        {
            return this.Insert<ProductOutputDto>(productEntity =>
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryId;

                productEntity.Prices.Add(this.CreatePriceFromDto(product.Price, CustomerTypeDto.Person));

                this.AddCompatibleCrates(productEntity, product);
            });
        }

        private Price CreatePriceFromDto(PriceDto dto, CustomerTypeDto customerType)
        {
            return new Price
            {
                Type = (CustomerType)customerType,
                UnitName = (UnitName)dto.UnitName,
                UnitMultiplier = dto.UnitMultiplier,
                Value = dto.Value
            };
        }

        public Task<ProductOutputDto> UpdateProduct(int productId, ProductInputDto product)
        {
            return this.Update<ProductOutputDto>(productId, productEntity =>
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryId;

                Price price = productEntity.Prices.Single();

                price.Value = product.Price.Value;
                price.UnitName = (UnitName)product.Price.UnitName;
                price.UnitMultiplier = product.Price.UnitMultiplier;

                this.AddCompatibleCrates(productEntity, product);
            });
        }

        private void AddCompatibleCrates(Product productEntity, ProductInputDto product)
        {
            productEntity.Compatibilities.Clear();
            product.CompatibleCrates.Select(c => new CrateCompatibility
            {
                CrateId = c.CrateId,
                Maximum = c.Maximum,
                Multiplier = c.Multiplier
            })
            .ForEach(productEntity.Compatibilities.Add);
        }

        protected override IQueryable<Product> GetDefaultQuery()
        {
            return this.Data.Products;
        }
    }
}
