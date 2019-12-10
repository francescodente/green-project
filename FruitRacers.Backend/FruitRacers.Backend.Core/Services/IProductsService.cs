using FruitRacers.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductOutputDto>> GetProductsForSupplier(int supplierId);

        Task<ProductOutputDto> GetProductData(int productId);

        Task<int> InsertProductForSupplier(int supplierId, ProductInputDto product);

        Task UpdateProductForSupplier(int supplierId, int productId, ProductInputDto product);

        Task DeleteProductForSupplier(int supplierId, int productId);
    }
}
