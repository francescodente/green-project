using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<PagedCollection<ProductOutputDto>> GetProducts(int userId, PaginationFilter pagination, ProductsFilters filters);

        Task<ProductOutputDto> InsertProduct(int userId, ProductInputDto product);

        Task<ProductOutputDto> UpdateProduct(int productId, int productId1, ProductInputDto product);

        Task DeleteProduct(int productId, int productId1);
    }
}
