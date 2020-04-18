using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public class OrderPrices
    {
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
