using FruitRacers.Backend.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductWithPricesDto<CategoryDto>>> GetProductsForSupplier(int supplierID);

        Task<ProductWithPricesDto<CategoryDto>> GetProductData(int productID);

        Task<int> InsertProductForSupplier(int supplierID, ProductWithPricesDto<int> product);

        Task UpdateProductForSupplier(int supplierID, ProductWithPricesDto<int> product);

        Task DeleteProductForSupplier(int supplierID, int productID);
    }
}
