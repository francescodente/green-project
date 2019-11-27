using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class ProductsService : AbstractService, IProductsService
    {
        public ProductsService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {
        }

        private async Task<Product> RequireProduct(int productId)
        {
            return await this.Session
                .Products
                .FindOne(p => p.ProductId == productId)
                .Then(p => p.OrElseThrow(() => new ProductNotFoundException()));
        }

        public async Task DeleteProductForSupplier(int supplierID, int productID)
        {
            Product product = await this.RequireProduct(productID);

            ServiceUtils.EnsureOwnership(supplierID, product.SupplierId);

            product.IsDeleted = true;
            await this.Session.Products.Update(product);
            await this.Session.SaveChanges();
        }

        public async Task<ProductWithPricesDto<CategoryDto>> GetProductData(int productID)
        {
            Product product = await this.RequireProduct(productID);
            return this.Mapper.Map<ProductWithPricesDto<CategoryDto>>(product);
        }

        public async Task<IEnumerable<ProductWithPricesDto<CategoryDto>>> GetProductsForSupplier(int supplierID)
        {
            return await this.Session
                .Products
                .BelongingTo(supplierID)
                .GetAll()
                .Then(p => p.Select(this.Mapper.Map<ProductWithPricesDto<CategoryDto>>));
        }

        public async Task<int> InsertProductForSupplier(int supplierID, ProductWithPricesDto<int> product)
        {
            Product productEntity = this.Mapper.Map<Product>(product);
            await this.Session.Products.Insert(productEntity);
            await this.Session.SaveChanges();
            return productEntity.ProductId;
        }

        public async Task UpdateProductForSupplier(int supplierID, ProductWithPricesDto<int> product)
        {
            Product productEntity = await this.RequireProduct(product.ProductId);

            ServiceUtils.EnsureOwnership(supplierID, productEntity.SupplierId);

            this.Mapper.Map(product, productEntity);
            await this.Session.Products.Update(productEntity);
            await this.Session.SaveChanges();
        }
    }
}
