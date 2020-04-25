using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public abstract class PurchasableItem
    {
        public PurchasableItem()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public decimal IvaPercentage { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int? ImageId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Image Image { get; set; }
    }
}
