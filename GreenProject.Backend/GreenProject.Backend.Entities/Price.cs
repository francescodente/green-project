using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Price
    {
        public CustomerType Type { get; set; }
        public decimal Value { get; set; }
        public decimal UnitMultiplier { get; set; }
        public UnitName UnitName { get; set; }
        public int ItemId { get; set; }

        public virtual PurchasableItem Item { get; set; }
    }
}
