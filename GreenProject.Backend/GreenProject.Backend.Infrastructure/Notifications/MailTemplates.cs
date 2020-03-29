using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using System;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public static class MailTemplates
    {
        public static Func<string, string> OrderReceived(Order order)
        {
            return t => t
                .Replace("{orderId}", order.OrderId.ToString())
                .Replace("{customerName}", order.User.GetCustomerName());
        }
    }
}
