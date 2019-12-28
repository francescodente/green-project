using FruitRacers.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductOutputDto>> GetProductsForSupplier(int supplierId);

        Task<ProductOutputDto> GetProductData(int productId);

        Task<ProductOutputDto> InsertProduct(ProductInputDto product);

        Task<ProductOutputDto> UpdateProduct(int productId, ProductInputDto product);

        Task DeleteProduct(int productId);
    }
}
