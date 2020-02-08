using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using System;

namespace FruitRacers.Backend.Infrastructure.Notifications
{
    public static class MailTemplates
    {
        public static Func<string, string> OrderReceived(OrderSection order)
        {
            return t => t
                .Replace("{orderId}", order.OrderId.ToString())
                .Replace("{supplierName}", order.Supplier.BusinessName)
                .Replace("{customerName}", order.Order.User.GetCustomerName());
        }

        internal static Func<string, string> SupplierRegistered(User supplier, string generatedPassword)
        {
            return t => t
                .Replace("{supplierName}", supplier.Supplier.BusinessName)
                .Replace("{password}", generatedPassword);
        }
    }
}
