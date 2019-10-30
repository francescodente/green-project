using FruitRacers.Backend.Core.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private const string ROOT_CATEGORY_NAME = "<root>";
        private readonly IDataSession session;

        public CategoriesService(IDataSession session)
        {
            this.session = session;
        }

        public async Task<CategoryTreeDto> GetAllCategories()
        {
            IList<Category> allCategories = (await this.session.Categories.GetAll()).ToList();
            IEnumerable<CategoryTreeDto> roots = allCategories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => CreateSubTree(c, allCategories)).ToArray();
            return new CategoryTreeDto
            {
                Category = new CategoryDto
                {
                    CategoryID = 0,
                    Name = ROOT_CATEGORY_NAME
                },
                Children = roots
            };
        }

        private CategoryTreeDto CreateSubTree(Category root, IList<Category> categories)
        {
            //categories.Remove(root);
            return new CategoryTreeDto
            {
                Category = CategoryEntityToDto(root),
                Children = categories
                    .Where(c => c.ParentCategoryId == root.CategoryId)
                    .Select(c => CreateSubTree(c, categories))
                    .ToArray()
            };
        }

        private CategoryDto CategoryEntityToDto(Category category)
        {
            return new CategoryDto
            {
                CategoryID = category.CategoryId,
                Name = category.Name
            };
        }
    }
}
