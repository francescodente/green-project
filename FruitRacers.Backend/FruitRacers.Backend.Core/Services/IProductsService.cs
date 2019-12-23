using FruitRacers.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductOutputDto>> GetProductsForSupplier(int supplierId);

        Task<ProductOutputDto> GetProductData(int productId);

        Task<int> InsertProduct(ProductInputDto product);

        Task UpdateProduct(int productId, ProductInputDto product);

        Task DeleteProduct(int productId);
    }
}
