using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using System.Linq;

namespace GreenProject.Backend.Infrastructure.Pricing
{
    public class DefaultPriceCalculator : IPricingService
    {
        private readonly PricingSettings _settings;

        public DefaultPriceCalculator(PricingSettings settings)
        {
            _settings = settings;
        }

        public OrderPrices CalculatePrices(Order order)
        {
            OrderPrices prices = new OrderPrices
            {
                Subtotal = order
                    .Details
                    .Select(d => d.Price * d.Quantity)
                    .Sum(d => d.Value),

                Iva = order
                    .Details
                    .Select(d => d.Price * d.Quantity * d.Item.IvaPercentage)
                    .Sum(d => d.Value),

                ShippingCost = order.Address.Zone.ShippingSurcharge
            };

            if (order.Details.Any(d => d.Item is Product))
            {
                prices.ShippingCost += _settings.ShippingCost;
            }

            return prices;
        }

        public OrderPrices CalculatePrices(CartDto cart)
        {
            OrderPrices prices = new OrderPrices
            {
                Subtotal = cart
                    .CartItems
                    .Select(i => i.Product.Price * i.Quantity)
                    .Sum(m => m.Value),

                Iva = cart
                    .CartItems
                    .Select(i => i.Product.Price * i.Quantity * i.Product.IvaPercentage)
                    .Sum(d => d.Value),

                ShippingCost = cart.CartItems.Any() ? _settings.ShippingCost : 0
            };

            return prices;
        }
    }
}
