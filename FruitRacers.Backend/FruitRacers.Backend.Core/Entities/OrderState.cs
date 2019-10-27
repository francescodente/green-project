using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class OrderState
    {
        public OrderState()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
