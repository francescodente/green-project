using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.Products;
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

        public async Task DeleteProductForSupplier(int supplierId, int productId)
        {
            Product product = await this.RequireProduct(productId);

            ServiceUtils.EnsureOwnership(supplierId, product.SupplierId);

            product.IsDeleted = true;
            await this.Session.Products.Update(product);
            await this.Session.SaveChanges();
        }

        public async Task<ProductOutputDto> GetProductData(int productId)
        {
            Product product = await this.RequireProduct(productId);
            return this.Mapper.Map<ProductOutputDto>(product);
        }

        public async Task<IEnumerable<ProductOutputDto>> GetProductsForSupplier(int supplierId)
        {
            return await this.Session
                .Products
                .BelongingTo(supplierId)
                .GetAll()
                .Then(p => p.Select(this.Mapper.Map<ProductOutputDto>));
        }

        public async Task<int> InsertProductForSupplier(int supplierId, ProductInputDto product)
        {
            Product productEntity = this.Mapper.Map<Product>(product);
            productEntity.SupplierId = supplierId;
            await this.Session.Products.Insert(productEntity);
            await this.Session.SaveChanges();
            return productEntity.ProductId;
        }

        public async Task UpdateProductForSupplier(int supplierId, int productId, ProductInputDto product)
        {
            Product productEntity = await this.RequireProduct(productId);

            ServiceUtils.EnsureOwnership(supplierId, productEntity.SupplierId);

            this.Mapper.Map(product, productEntity);
            await this.Session.Products.Update(productEntity);
            await this.Session.SaveChanges();
        }
    }
}
