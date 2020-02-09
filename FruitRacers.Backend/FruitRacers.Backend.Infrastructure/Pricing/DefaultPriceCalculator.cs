using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Utils.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Infrastructure.Pricing
{
    public class DefaultPriceCalculator : IPriceCalculator
    {
        private readonly PricingSettings settings;

        public DefaultPriceCalculator(PricingSettings settings)
        {
            this.settings = settings;
        }

        public OrderPricesDto Calculate(Order order)
        {
            return new OrderPricesDto
            {

            };
        }
    }
}
