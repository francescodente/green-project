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

                productEntity.Price = product.Price.Value;
                productEntity.UnitName = product.Price.UnitName;
                productEntity.UnitMultiplier = product.Price.UnitMultiplier;

                this.AddCompatibleCrates(productEntity, product);
            });
        }

        private void AddCompatibleCrates(Product productEntity, ProductInputDto product)
        {
            product.CompatibleCrates.Select(c => new CrateCompatibility
            {
                CrateId = c.CrateId,
                Maximum = c.Maximum
            })
            .ForEach(productEntity.Compatibilities.Add);
        }

        public Task<ProductOutputDto> UpdateProduct(int productId, ProductInputDto product)
        {
            return this.Update<ProductOutputDto>(productId, productEntity =>
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryId;

                productEntity.Price = product.Price.Value;
                productEntity.UnitName = product.Price.UnitName;
                productEntity.UnitMultiplier = product.Price.UnitMultiplier;

                productEntity.Compatibilities.Clear();
                this.AddCompatibleCrates(productEntity, product);
            }, q => q.Include(p => p.Compatibilities));
        }

        private void UpdateCrateCompatibilities(Product productEntity, ProductInputDto productInput)
        {
            productEntity.Compatibilities
                .Where(c => productInput.CompatibleCrates.All(comp => comp.CrateId != c.CrateId))
                .ToArray()
                .ForEach(c => productEntity.Compatibilities.Remove(c));

            productEntity.Compatibilities.Join(productInput.CompatibleCrates, c => c.CrateId, c => c.CrateId, (e, d) => (e, d))
                .ForEach(p =>
                {
                    p.e.Maximum = p.d.Maximum;
                });

            productInput.CompatibleCrates
                .Where(c => productEntity.Compatibilities.All(comp => comp.CrateId != c.CrateId))
                .Select(c => new CrateCompatibility
                {
                    CrateId = c.CrateId,
                    Maximum = c.Maximum
                })
                .ForEach(c => productEntity.Compatibilities.Add(c));
        }

        protected override IQueryable<Product> GetDefaultQuery()
        {
            return this.Data.Products;
        }
    }
}
