using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using System.Linq;

namespace GreenProject.Backend.Infrastructure.Pricing
{
    public class DefaultPriceCalculator : IPricingService
    {
        private readonly PricingSettings settings;

        public DefaultPriceCalculator(PricingSettings settings)
        {
            this.settings = settings;
        }

        public OrderPrices CalculatePrices(Order order)
        {
            OrderPrices prices = new OrderPrices();

            prices.Subtotal = order
                .Details
                .Select(d => d.Price * d.Quantity)
                .Sum();

            prices.Iva = this.settings.ProductsIvaPercentage * prices.Subtotal;

            prices.ShippingCost = order.Details.Any(d => d.Item is Product) ? this.settings.ShippingCost : 0;

            return prices;
        }

        public OrderPrices CalculatePrices(CartOutputDto cart)
        {
            OrderPrices prices = new OrderPrices();

            prices.Subtotal = cart
                .Items
                .Select(i => i.Product.Price.Value * i.Quantity)
                .Sum();

            prices.Iva = this.settings.ProductsIvaPercentage * prices.Subtotal;

            prices.ShippingCost = this.settings.ShippingCost;

            return prices;
        }
    }
}
