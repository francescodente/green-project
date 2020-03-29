using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<PagedCollection<ProductOutputDto>> GetProducts(PaginationFilter pagination, ProductsFilters filters);

        Task<ProductOutputDto> InsertProduct(ProductInputDto product);

        Task<ProductOutputDto> UpdateProduct(int productId, ProductInputDto product);

        Task DeleteProduct(int productId);
    }
}
