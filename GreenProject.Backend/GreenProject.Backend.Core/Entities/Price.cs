using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Price
    {
        public CustomerType Type { get; set; }
        public decimal Value { get; set; }
        public decimal UnitMultiplier { get; set; }
        public int Minimum { get; set; }
        public string UnitName { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
