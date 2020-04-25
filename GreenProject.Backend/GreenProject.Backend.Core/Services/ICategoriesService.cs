using GreenProject.Backend.Contracts.Categories;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICategoriesService
    {
        Task<CategoryDto.Tree> GetCategoryTree();

        Task<CategoryDto.Output> AddCategory(CategoryDto.Input category);
    }
}
