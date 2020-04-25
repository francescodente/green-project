﻿using GreenProject.Backend.Entities;
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
            return new OrderDetail
            {
                Item = item.Product,
                Quantity = item.Quantity,
                Price = item.Product.Price
            };
        }
    }
}
