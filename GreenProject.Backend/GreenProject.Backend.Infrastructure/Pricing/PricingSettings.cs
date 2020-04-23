using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Pricing
{
    public class PricingSettings
    {
        public decimal ProductsIvaPercentage { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
