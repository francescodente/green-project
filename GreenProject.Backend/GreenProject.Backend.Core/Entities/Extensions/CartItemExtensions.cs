using GreenProject.Backend.Entities;
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
            OrderDetail detail = new OrderDetail
            {
                Item = item.Product,
                Quantity = item.Quantity
            };
            return detail.WithPrices(price);
        }

        public static OrderDetail WithPrices(this OrderDetail detail, Price price)
        {
            detail.Price = price.Value;
            detail.UnitName = price.UnitName;
            detail.UnitMultiplier = price.UnitMultiplier;
            return detail;
        }
    }
}
