using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Prices = new HashSet<Price>();
        }

        public string UnitName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
