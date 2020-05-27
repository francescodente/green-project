using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Contracts.PurchasableItems;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IProductsService
    {
        Task<PagedCollection<ProductDto.Output>> GetProducts(PaginationFilter pagination, PurchasableFilters filters);

        Task<ProductDto.Output> InsertProduct(ProductDto.Insertion product);

        Task<ProductDto.Output> UpdateProduct(int productId, ProductDto.Update product);

        Task DeleteProduct(int productId);
    }
}
