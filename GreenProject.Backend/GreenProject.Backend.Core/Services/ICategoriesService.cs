using GreenProject.Backend.Contracts.Categories;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICategoriesService
    {
        Task<CategoryTreeDto> GetCategoryTree();

        Task<CategoryOutputDto> AddCategory(CategoryInputDto category);
    }
}
