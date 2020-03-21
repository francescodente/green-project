using FruitRacers.Backend.Core.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Categories;
using Microsoft.EntityFrameworkCore;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Core.Logic.Utils;

namespace FruitRacers.Backend.Core.Logic
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
            IList<Category> allCategories = await this.Data
                .Categories
                .Include(c => c.Image)
                .ToListAsync();

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
