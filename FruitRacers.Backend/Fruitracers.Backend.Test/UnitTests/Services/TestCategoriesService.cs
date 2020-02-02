using FruitRacers.Backend.Test.UnitTests.Mocking;
using FruitRacers.Backend.Core;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Services.Impl;
using FruitRacers.Backend.Shared.Utils;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Infrastructure.Mapping;

namespace FruitRacers.Backend.Test.UnitTests.Services
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

            IDataSession data = Substitute.For<IDataSession>();
            data.Categories.Returns(MockingUtils.CreateMockReadOnlyRepository(categories));

            IUserSession user = Substitute.For<IUserSession>();
            user.IsLoggedIn.Returns(false);

            IRequestSession request = Substitute.For<IRequestSession>();
            request.User.Returns(user);
            request.Data.Returns(data);

            ICategoriesService categoriesService = new CategoriesService(request, MappingUtils.CreateDefaultMapper());

            CategoryTreeDto actual = categoriesService.GetCategoryTree().Result;

            CategoryTreeDto expected = ParseTree("0137$$4$$265$$8$$$");

            AssertTreeEquals(expected, actual);
        }

        private void AssertTreeEquals(CategoryTreeDto expected, CategoryTreeDto actual)
        {
            Assert.AreEqual(expected.Category.CategoryId, actual.Category.CategoryId);
            Assert.AreEqual(expected.Children.Count(), actual.Children.Count());
            Enumerable.Zip(
                expected.Children.OrderBy(c => c.Category.CategoryId),
                actual.Children.OrderBy(c => c.Category.CategoryId)
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
                Category = new CategoryDto { CategoryId = int.Parse(characters.Current.ToString()) },
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
