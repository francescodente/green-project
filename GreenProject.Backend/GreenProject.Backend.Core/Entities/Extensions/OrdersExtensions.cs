using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.Core.Entities.Extensions
{
    public static class OrdersExtensions
    {
        private static IDictionary<OrderState, ISet<OrderState>> validStateTransitions;

        static OrdersExtensions()
        {
            validStateTransitions = new Dictionary<OrderState, ISet<OrderState>>
            {
                { OrderState.Pending, new HashSet<OrderState> { OrderState.Shipping, OrderState.Canceled } },
                { OrderState.Shipping, new HashSet<OrderState> { OrderState.Completed } },
                { OrderState.Completed, new HashSet<OrderState> { } },
                { OrderState.Canceled, new HashSet<OrderState> { } }
            };
        }

        public static void ChangeState(this Order order, OrderState newState)
        {
            if (!validStateTransitions[order.OrderState].Contains(newState))
            {
                throw new InvalidStateChangeException(order.OrderState, newState);
            }

            order.OrderState = newState;
        }

        public static OrderDetail CreateCopy(this OrderDetail detail)
        {
            OrderDetail copy = new OrderDetail
            {
                ItemId = detail.ItemId,
                Quantity = detail.Quantity,
                Price = detail.Item.Prices.Single().Value
            };

            detail.SubProducts
                .Select(CreateCopy)
                .ForEach(copy.SubProducts.Add);

            return copy;
        }

        private static OrderDetailSubProduct CreateCopy(this OrderDetailSubProduct subProduct)
        {
            return new OrderDetailSubProduct
            {
                ProductId = subProduct.ProductId,
                Quantity = subProduct.Quantity
            };
        }
    }
}
