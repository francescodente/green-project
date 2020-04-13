using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.Infrastructure.Pricing
{
    public class DefaultPriceCalculator : IPriceCalculator
    {
        private readonly PricingSettings settings;

        public DefaultPriceCalculator(PricingSettings settings)
        {
            this.settings = settings;
        }

        public OrderPricesDto Calculate(IEnumerable<CartItem> items, CustomerType customerType)
        {
            OrderPricesDto prices = new OrderPricesDto();

            prices.Subtotal = items.Select(i => this.GetPriceForCartItem(i, customerType)).Sum();
            prices.Iva = prices.Subtotal * this.settings.ProductsIvaPercentage;
            prices.ShippingCost = items.Any() ? this.settings.ShippingCost : 0;

            return prices;
        }

        private decimal GetPriceForCartItem(CartItem item, CustomerType customerType)
        {
            return item.Product.GetPrice(customerType).Value.Value * item.Quantity;
        }

        public void UpdateOrderPrices(Order order)
        {
            order.Subtotal = order
                .Details
                .Select(d => this.GetPriceForItem(d))
                .Sum();

            order.Iva = this.settings.ProductsIvaPercentage * order.Subtotal;
        }

        private decimal GetPriceForItem(OrderDetail detail)
        {
            return detail.Price * detail.Quantity;
        }
    }
}
