using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public class OrderPrices
    {
        public Money Subtotal { get; set; }
        public Money Iva { get; set; }
        public Money ShippingCost { get; set; }
    }
}
