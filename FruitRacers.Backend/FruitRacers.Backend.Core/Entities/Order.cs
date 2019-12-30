using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Order
    {
        public Order()
        {
            Sections = new HashSet<OrderSection>();
        }

        public int OrderId { get; set; }
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? Timestamp { get; set; }
        public OrderState OrderState { get; set; }
        public int? TimeSlotId { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderSection> Sections { get; set; }
    }
}
