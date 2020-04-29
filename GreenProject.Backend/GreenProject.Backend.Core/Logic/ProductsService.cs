using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.Core.Logic
{
    public class ProductsService : AbstractItemsService<Product>, IProductsService
    {
        public ProductsService(IRequestSession request)
            : base(request)
        {
        }

        public Task<PagedCollection<ProductDto.Output>> GetProducts(PaginationFilter pagination, PurchasableFilters filters)
        {
            return this.GetPaged<ProductDto.Output>(pagination, filters);
        }

        public Task DeleteProduct(int productId)
        {
            return this.Delete(productId);
        }

        public Task<ProductDto.Output> InsertProduct(ProductDto.Insertion product)
        {
            return this.Insert<ProductDto.Output>(productEntity =>
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryId;
                productEntity.Price = product.Price;
                productEntity.UnitName = product.UnitName;
                productEntity.UnitMultiplier = product.UnitMultiplier;
                productEntity.IvaPercentage = product.IvaPercentage;

                this.AddCompatibleCrates(productEntity, product.CompatibleCrates);
            });
        }

        private void AddCompatibleCrates(Product productEntity, IEnumerable<CompatibilityDto.Input> compatibilities)
        {
            compatibilities.Select(c => new CrateCompatibility
            {
                CrateId = c.CrateId,
                Maximum = c.Maximum
            })
            .ForEach(productEntity.Compatibilities.Add);
        }

        public Task<ProductDto.Output> UpdateProduct(int productId, ProductDto.Update product)
        {
            return this.Update<ProductDto.Output>(productId, productEntity =>
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryId;

                productEntity.Price = product.Price.Value;
                productEntity.IvaPercentage = product.IvaPercentage;

                productEntity.Compatibilities.Clear();
                this.AddCompatibleCrates(productEntity, product.CompatibleCrates);
            }, q => q.Include(p => p.Compatibilities));
        }

        protected override IQueryable<Product> GetDefaultQuery()
        {
            return this.Data.Products;
        }
    }
}
