﻿using GreenProject.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Pricing
{
    public class PricingSettings
    {
        public decimal ProductsIvaPercentage { get; set; }
        public decimal ShippingCost { get; set; }
        public IDictionary<CustomerType, decimal> FreeShippingThreshold { get; set; }
    }
}