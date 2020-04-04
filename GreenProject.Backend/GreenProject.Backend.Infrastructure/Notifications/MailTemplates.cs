using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using System;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public static class MailTemplates
    {
        public static Func<string, string> OrderReceived(Order order)
        {
            return template => template
                .Replace("{orderId}", order.OrderNumber)
                .Replace("{customerName}", order.User.GetCustomerName());
        }

        public static Func<string, string> OrderStateChanged(Order order)
        {
            return template => template;
        }
    }
}
