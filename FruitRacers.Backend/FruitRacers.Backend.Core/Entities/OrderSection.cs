using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Entities
{
    public class OrderSection
    {
        public OrderSection()
        {
            Details = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public OrderSectionState State { get; set; }

        public virtual Order Order { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; }
    }
}
