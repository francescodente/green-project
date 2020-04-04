using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Entities.Extensions
{
    public static class CartItemExtensions
    {
        public static OrderDetail CreateOrderDetail(this CartItem item, CustomerType customerType)
        {
            Price price = item.Product.GetPrice(customerType).OrElseThrow(() => new Exception());
            return new OrderDetail
            {
                Item = item.Product,
                Quantity = item.Quantity,
                Price = price.Value,
                UnitName = price.UnitName,
                UnitMultiplier = price.UnitMultiplier
            };
        }
    }
}
