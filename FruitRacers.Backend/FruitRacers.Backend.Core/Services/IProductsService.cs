using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductOutputDto>> GetProducts(PaginationFilter pagination, ProductsFilters filters);

        Task<ProductOutputDto> InsertProduct(ProductInputDto product);

        Task<ProductOutputDto> UpdateProduct(int productId, ProductInputDto product);

        Task DeleteProduct(int productId);
    }
}
