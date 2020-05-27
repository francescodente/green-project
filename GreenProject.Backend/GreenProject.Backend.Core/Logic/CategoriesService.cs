using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class CategoriesService : AbstractService, ICategoriesService
    {
        private const string RootCategoryName = "<root>";

        public CategoriesService(IRequestSession request)
            : base(request)
        {

        }

        public async Task<CategoryDto.Output> AddCategory(CategoryDto.Input category)
        {
            var entity = new Category
            {
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId
            };

            Data.Categories.Add(entity);

            await Data.SaveChangesAsync();

            return Mapper.Map<CategoryDto.Output>(entity);
        }

        public async Task<CategoryDto.Tree> GetCategoryTree()
        {
            IList<Category> allCategories = await Data
                .Categories
                .Include(c => c.Image)
                .ToListAsync();

            IEnumerable<CategoryDto.Tree> roots = allCategories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => CreateSubTree(c, allCategories)).ToArray();

            return new CategoryDto.Tree
            {
                Name = RootCategoryName,
                Children = roots
            };
        }

        private CategoryDto.Tree CreateSubTree(Category root, IList<Category> categories)
        {
            IEnumerable<CategoryDto.Tree> children = categories
                    .Where(c => c.ParentCategoryId == root.CategoryId)
                    .Select(c => CreateSubTree(c, categories))
                    .ToArray();

            return Mapper.Map(root, new CategoryDto.Tree { Children = children });
        }
    }
}
