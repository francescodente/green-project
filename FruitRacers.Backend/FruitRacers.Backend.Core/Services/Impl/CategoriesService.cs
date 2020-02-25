using FruitRacers.Backend.Core.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Core.Session;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CategoriesService : AbstractService, ICategoriesService
    {
        private const string ROOT_CATEGORY_NAME = "<root>";

        public CategoriesService(IRequestSession request)
            : base(request)
        {

        }

        public async Task<CategoryTreeDto> GetCategoryTree()
        {
            IList<Category> allCategories = (await this.Data.Categories.AsEnumerable()).ToList();
            IEnumerable<CategoryTreeDto> roots = allCategories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => CreateSubTree(c, allCategories)).ToArray();
            return new CategoryTreeDto
            {
                Category = new CategoryDto
                {
                    CategoryId = 0,
                    Name = ROOT_CATEGORY_NAME
                },
                Children = roots
            };
        }

        private CategoryTreeDto CreateSubTree(Category root, IList<Category> categories)
        {
            return new CategoryTreeDto
            {
                Category = this.Mapper.Map<Category, CategoryDto>(root),
                Children = categories
                    .Where(c => c.ParentCategoryId == root.CategoryId)
                    .Select(c => CreateSubTree(c, categories))
                    .ToArray()
            };
        }
    }
}
