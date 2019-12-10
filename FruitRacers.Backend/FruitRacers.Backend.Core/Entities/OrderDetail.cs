using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public string UnitName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? UnitMultiplier { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
