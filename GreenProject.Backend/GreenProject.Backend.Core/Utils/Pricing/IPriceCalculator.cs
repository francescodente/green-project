using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public interface IPriceCalculator
    {
        void UpdateOrderPrices(Order order);

        OrderPricesDto Calculate(IEnumerable<CartItem> items, CustomerType customerType);
    }
}
