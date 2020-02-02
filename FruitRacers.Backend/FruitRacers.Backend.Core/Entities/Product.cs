using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Prices = new HashSet<Price>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsLegal { get; set; }
        public bool IsDeleted { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int? ImageId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual Image Image { get; set; }
    }
}
