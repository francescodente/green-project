using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public byte[] Timestamp { get; set; }
        public int OrderStateId { get; set; }
        public int? TimeSlotId { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual OrderState OrderState { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
