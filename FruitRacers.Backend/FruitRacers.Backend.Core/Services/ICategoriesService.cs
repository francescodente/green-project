using FruitRacers.Backend.Contracts.Categories;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICategoriesService
    {
        Task<CategoryTreeDto> GetCategoryTree();
    }
}
