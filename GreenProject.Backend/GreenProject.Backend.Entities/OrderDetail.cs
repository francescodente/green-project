using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Entities
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            SubProducts = new HashSet<OrderDetailSubProduct>();
        }

        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; }
        public int RemainingSlots { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public virtual Order Order { get; set; }
        public virtual PurchasableItem Item { get; set; }
        public virtual ICollection<OrderDetailSubProduct> SubProducts { get; set; }
    }
}
