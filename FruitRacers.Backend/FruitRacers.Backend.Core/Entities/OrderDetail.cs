using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public OrderDetailState State { get; set; }
        public decimal? Price { get; set; }
        public decimal? UnitMultiplier { get; set; }

        public virtual OrderSection OrderSection { get; set; }
        public virtual Product Product { get; set; }
    }
}
