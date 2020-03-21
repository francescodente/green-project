using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.Core.Logic
{
    public class ProductsService : AbstractService, IProductsService
    {
        public ProductsService(IRequestSession request)
            : base(request)
        {
        }

        private Task<Product> RequireProduct(int productId)
        {
            return this.Data
                .Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Prices)
                .Include(p => p.Image)
                .SingleOptionalAsync(p => p.ProductId == productId)
                .Map(p => p.OrElseThrow(() => new ProductNotFoundException(productId)));
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            Product product = await this.RequireProduct(productId);

            ServiceUtils.RequireOwnership(product.SupplierId, userId);

            product.IsDeleted = true;

            await this.Data.SaveChangesAsync();
        }

        public async Task<PagedCollection<ProductOutputDto>> GetProducts(int userId, PaginationFilter pagination, ProductsFilters filters)
        {
            IQueryable<Product> products = this.Data
                .Products
                .Where(p => p.SupplierId == userId);

            products = filters.Categories != null && filters.Categories.Any()
                ? products.Where(p => filters.Categories.Contains(p.CategoryId))
                : products;

            return await products.ToPagedCollection(pagination, this.Mapper.Map<ProductOutputDto>);
        }

        public async Task<ProductOutputDto> InsertProduct(int userId, ProductInputDto product)
        {
            Product productEntity = new Product
            {
                SupplierId = userId,
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

            this.Data.Products.Add(productEntity);
            await this.Data.SaveChangesAsync();
            return this.Mapper.Map<ProductOutputDto>(productEntity);
        }

        private Price CreatePriceFromDto(PriceDto dto, CustomerTypeDto customerType)
        {
            return new Price
            {
                Type = (CustomerType)customerType,
                UnitName = dto.UnitName,
                UnitMultiplier = dto.UnitMultiplier,
                Value = dto.Value,
                Minimum = dto.Minimum
            };
        }

        public async Task<ProductOutputDto> UpdateProduct(int userId, int productId, ProductInputDto product)
        {
            Product productEntity = await this.RequireProduct(productId);

            ServiceUtils.RequireOwnership(productEntity.SupplierId, userId);

            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.CategoryId = product.CategoryId;

            IList<Price> pricesToAdd = product.Prices
                .Where(p => !productEntity.Prices.Select(e => e.Type).Contains((CustomerType)p.Key))
                .Select(p => this.CreatePriceFromDto(p.Value, p.Key))
                .ToList();

            IList<Price> pricesToRemove = productEntity.Prices
                .Where(p => !product.Prices.ContainsKey((CustomerTypeDto)p.Type))
                .ToList();

            pricesToAdd.ForEach(p => productEntity.Prices.Add(p));
            pricesToRemove.ForEach(p => productEntity.Prices.Remove(p));

            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<ProductOutputDto>(product);
        }
    }
}
