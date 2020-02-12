using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class ProductsService : AbstractService, IProductsService
    {
        public ProductsService(IRequestSession request)
            : base(request)
        {
        }

        private async Task<Product> RequireProduct(int productId)
        {
            return await this.Data
                .Products
                .FindOne(p => p.ProductId == productId)
                .Then(p => p.OrElseThrow(() => new ProductNotFoundException(productId)));
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            Product product = await this.RequireProduct(productId);

            ServiceUtils.RequireOwnership(product.SupplierId, this.RequestingUser.UserId);

            product.IsDeleted = true;

            await this.Data.SaveChanges();
        }

        public async Task<PagedCollection<ProductOutputDto>> GetProducts(int userId, PaginationFilter pagination, ProductsFilters filters)
        {
            IProductRepository products = this.Data.Products.BelongingTo(userId);

            products = filters.Categories != null && filters.Categories.Any()
                ? products.WithCategories(filters.Categories)
                : products;

            return await ServiceUtils.PagedCollectionFromRepository<Product, ProductOutputDto>(products, pagination, this.Mapper);
        }

        public async Task<ProductOutputDto> InsertProduct(int userId, ProductInputDto product)
        {
            Product productEntity = new Product
            {
                SupplierId = this.RequestingUser.UserId,
                Description = product.Description,
                Name = product.Name,
                CategoryId = product.CategoryId,
                IsDeleted = false,
                IsEnabled = true,
                IsLegal = true
            };

            product.Prices
                .Select(p => this.CreatePriceFromDto(p.Value, p.Key))
                .ForEach(productEntity.Prices.Add);

            await this.Data.Products.Insert(productEntity);
            await this.Data.SaveChanges();
            return this.Mapper.Map<ProductOutputDto>(productEntity);
        }

        private Price CreatePriceFromDto(PriceDto dto, CustomerTypeDto customerType)
        {
            return new Price
            {
                Type = (CustomerType) customerType,
                UnitName = dto.UnitName,
                UnitMultiplier = dto.UnitMultiplier,
                Value = dto.Value,
                Minimum = dto.Minimum
            };
        }

        public async Task<ProductOutputDto> UpdateProduct(int userId, int productId, ProductInputDto product)
        {
            Product productEntity = await this.RequireProduct(productId);

            ServiceUtils.RequireOwnership(productEntity.SupplierId, this.RequestingUser.UserId);

            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.CategoryId = product.CategoryId;

            IList<Price> pricesToAdd = product.Prices
                .Where(p => !productEntity.Prices.Select(e => e.Type).Contains((CustomerType) p.Key))
                .Select(p => this.CreatePriceFromDto(p.Value, p.Key))
                .ToList();

            IList<Price> pricesToRemove = productEntity.Prices
                .Where(p => !product.Prices.ContainsKey((CustomerTypeDto) p.Type))
                .ToList();

            pricesToAdd.ForEach(p => productEntity.Prices.Add(p));
            pricesToRemove.ForEach(p => productEntity.Prices.Remove(p));

            await this.Data.SaveChanges();

            return this.Mapper.Map<ProductOutputDto>(product);
        }
    }
}
