﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.Products;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.Core.Logic
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
                .Map(p => p.OrElseThrow(() => NotFoundException.ProductWithId(productId)));
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            Product product = await this.RequireProduct(productId);

            ServiceUtils.RequireOwnership(product.SupplierId, userId);

            product.IsDeleted = true;

            await this.Data.SaveChangesAsync();
        }

        public Task<PagedCollection<ProductOutputDto>> GetProducts(int userId, PaginationFilter pagination, ProductsFilters filters)
        {
            IQueryable<Product> products = this.Data
                .Products
                .Where(p => p.SupplierId == userId);

            products = filters.Categories != null && filters.Categories.Any()
                ? products.Where(p => filters.Categories.Contains(p.CategoryId))
                : products;

            return products.ToPagedCollection(pagination, this.Mapper.Map<ProductOutputDto>);
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