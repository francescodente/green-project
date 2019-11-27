using FruitRacers.Backend.Core.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Dto;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CategoriesService : AbstractService, ICategoriesService
    {
        private const string ROOT_CATEGORY_NAME = "<root>";

        public CategoriesService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {

        }

        public async Task<CategoryTreeDto> GetCategoryTree()
        {
            IList<Category> allCategories = (await this.Session.Categories.GetAll()).ToList();
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
