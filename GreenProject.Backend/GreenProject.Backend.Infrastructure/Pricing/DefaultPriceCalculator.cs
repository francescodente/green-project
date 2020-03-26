using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Shared.Utils;
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

        public OrderPricesDto Calculate(OrderSection order)
        {
            CustomerType customerType = order.Order
                .User
                .AsOptional()
                .FlatMap(u => u.GetCustomerType())
                .OrElse(CustomerType.Person);
            return this.Calculate(order, customerType);
        }

        private OrderPricesDto Calculate(OrderSection section, CustomerType customerType)
        {
            OrderPricesDto prices = new OrderPricesDto();

            prices.SubTotal = section
                .Details
                .Where(d => d.State != OrderDetailState.Removed)
                .Select(d => this.GetPriceForItem(d, customerType))
                .Sum();
            prices.Iva = this.settings.ProductsIvaPercentage * prices.SubTotal;
            if (prices.SubTotal <= this.settings.FreeShippingThreshold[customerType])
            {
                prices.ShippingCost = this.settings.ShippingCost;
            }

            return prices;
        }

        private decimal GetPriceForItem(OrderDetail detail, CustomerType customerType)
        {
            return (detail.Price ?? detail.Product.GetPrice(customerType).Value.Value) * detail.Quantity;
        }
    }
}
