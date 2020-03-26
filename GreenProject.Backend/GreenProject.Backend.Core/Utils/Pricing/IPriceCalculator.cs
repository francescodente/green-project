using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public interface IPriceCalculator
    {
        OrderPricesDto Calculate(OrderSection order);
    }
}
