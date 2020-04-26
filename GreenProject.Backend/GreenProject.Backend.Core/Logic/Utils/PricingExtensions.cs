using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public static class PricingExtensions
    {
        public static void AssignPricesToOrder(this IPricingService pricing, Order order)
        {
            OrderPrices prices = pricing.CalculatePrices(order);

            order.Subtotal = prices.Subtotal;
            order.ShippingCost = prices.ShippingCost;
            order.Iva = prices.Iva;
        }

        public static void AssignPricesToCart(this IPricingService pricing, CartDto cart)
        {
            OrderPrices prices = pricing.CalculatePrices(cart);

            cart.Prices = new OrderPricesDto
            {
                Subtotal = prices.Subtotal,
                ShippingCost = prices.ShippingCost,
                Iva = prices.Iva
            };
        }
    }
}
