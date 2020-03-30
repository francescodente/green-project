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

        public void Calculate(Order order)
        {
            CustomerType customerType = order
                .User
                .GetCustomerType()
                .OrElse(CustomerType.Person);

            this.Calculate(order, customerType);
        }

        private void Calculate(Order order, CustomerType customerType)
        {
            order.Subtotal = order
                .Details
                .Select(d => this.GetPriceForItem(d, customerType))
                .Sum();

            order.Iva = this.settings.ProductsIvaPercentage * order.Subtotal;
        }

        private decimal GetPriceForItem(OrderDetail detail, CustomerType customerType)
        {
            return detail.Item.GetPrice(customerType).Value.Value * detail.Quantity;
        }
    }
}
