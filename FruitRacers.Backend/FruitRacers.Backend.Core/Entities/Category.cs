using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
