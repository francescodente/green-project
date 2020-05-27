using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Categories
{
    public static class CategoryDto
    {
        public class Input
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int? ParentCategoryId { get; set; }
        }

        public class Output
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
        }

        public class Tree
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public IEnumerable<Tree> Children { get; set; }
        }
    }
}
