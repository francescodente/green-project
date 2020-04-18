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
        public UnitName? UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal? UnitMultiplier { get; set; }
        public int RemainingSlots { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public virtual Order Order { get; set; }
        public virtual PurchasableItem Item { get; set; }
        public virtual ICollection<OrderDetailSubProduct> SubProducts { get; set; }
    }
}
