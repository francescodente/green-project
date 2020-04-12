using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
            PurchasableItems = new HashSet<PurchasableItem>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<PurchasableItem> PurchasableItems { get; set; }
    }
}
