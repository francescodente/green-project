using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Pricing
{
    public interface IPriceCalculator
    {
        OrderPricesDto Calculate(Order order);
    }
}
