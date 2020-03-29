using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Linq;

namespace GreenProject.Backend.Core.Entities.Extensions
{
    public static class OrdersExtensions
    {
        public static void Confirm(this Order order, DateTime timestamp)
        {
            CustomerType customerType = order.User
                .GetCustomerType()
                .OrElseThrow(() => new UnauthorizedPurchaseException());

            order.MaterializePrices(customerType);

            order.OrderState = OrderState.Pending;
            order.Timestamp = timestamp;
        }

        private static void MaterializePrices(this Order order, CustomerType customerType)
        {
            order.Details.ForEach(d => d.AssignCurrentDetailPrice(customerType));
        }

        private static void AssignCurrentDetailPrice(this OrderDetail detail, CustomerType customerType)
        {
            Price price = detail
                .Item
                .GetPrice(customerType)
                .OrElseThrow(() => new ReservedProductException(detail.ItemId, customerType));

            detail.Price = price.Value;
            detail.UnitName = price.UnitName;
            detail.UnitMultiplier = price.UnitMultiplier;
        }
    }
}
