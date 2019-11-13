using AutoMapper;
using Fruitracers.Backend.Test.UnitTests.Mocking;
using FruitRacers.Backend.Core;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Services.Categories;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Shared.Utils;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruitracers.Backend.Test.UnitTests.Services
{
    public class TestCategoriesService
    {
        [Test]
        public void GeneratesCorrectCategoryTree()
        {
            IEnumerable<Category> categories = new Category[]
            {
                new Category { CategoryId = 1, ParentCategoryId = null },
                new Category { CategoryId = 2, ParentCategoryId = null },
                new Category { CategoryId = 3, ParentCategoryId = 1 },
                new Category { CategoryId = 4, ParentCategoryId = 1 },
                new Category { CategoryId = 5, ParentCategoryId = 6 },
                new Category { CategoryId = 6, ParentCategoryId = 2 },
                new Category { CategoryId = 7, ParentCategoryId = 3 },
                new Category { CategoryId = 8, ParentCategoryId = 2 }
            };

            IDataSession session = Substitute.For<IDataSession>();
            session.Categories.Returns(MockingUtils.CreateMockReadOnlyRepository(categories));

            ICategoriesService categoriesService = new CategoriesService(session, MappingUtils.CreateDefaultMapper());

            CategoryTreeDto actual = categoriesService.GetAllCategories().Result;

            CategoryTreeDto expected = ParseTree("0137$$4$$265$$8$$$");

            AssertTreeEquals(expected, actual);
        }

        private void AssertTreeEquals(CategoryTreeDto expected, CategoryTreeDto actual)
        {
            Assert.AreEqual(expected.Category.CategoryID, actual.Category.CategoryID);
            Assert.AreEqual(expected.Children.Count(), actual.Children.Count());
            Enumerable.Zip(
                expected.Children.OrderBy(c => c.Category.CategoryID),
                actual.Children.OrderBy(c => c.Category.CategoryID)
            ).ForEach(p => AssertTreeEquals(p.First, p.Second));
        }

        private CategoryTreeDto ParseTree(string s)
        {
            return ParseTree(s.GetEnumerator());
        }

        private CategoryTreeDto ParseTree(CharEnumerator characters)
        {
            if (!characters.MoveNext() || characters.Current == '$')
            {
                return null;
            }
            IList<CategoryTreeDto> subTrees = new List<CategoryTreeDto>();
            CategoryTreeDto root = new CategoryTreeDto
            {
                Category = new CategoryDto { CategoryID = int.Parse(characters.Current.ToString()) },
                Children = subTrees
            };
            CategoryTreeDto curr = ParseTree(characters);
            while (curr != null)
            {
                subTrees.Add(curr);
                curr = ParseTree(characters);
            }
            return root;
        }
    }
}
