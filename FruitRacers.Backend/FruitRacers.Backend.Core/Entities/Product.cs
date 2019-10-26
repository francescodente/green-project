using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetail>();
            Prices = new HashSet<Price>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsLegal { get; set; }
        public bool IsDeleted { get; set; }
        public int SupplierId { get; set; }

        public virtual UserBusinessSupplier Supplier { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
