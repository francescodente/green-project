using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Order
    {
        public Order()
        {
            Details = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Notes { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime Timestamp { get; set; }
        public OrderState OrderState { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal ShippingCost { get; set; }
        public bool IsSubscription { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; }
    }
}
