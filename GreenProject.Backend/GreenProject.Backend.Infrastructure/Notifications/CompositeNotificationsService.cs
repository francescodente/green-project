using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public class CompositeNotificationsService : INotificationsService
    {
        private readonly IEnumerable<INotificationsService> _services;

        public CompositeNotificationsService(IEnumerable<INotificationsService> services)
        {
            _services = services;
        }

        private Task DelegateRequest(Func<INotificationsService, Task> notification)
        {
            return Task.WhenAll(_services.Select(notification));
        }

        public Task AccountConfirmation(User user, string token)
        {
            return DelegateRequest(s => s.AccountConfirmation(user, token));
        }

        public Task OrderAccepted(Order order)
        {
            return DelegateRequest(s => s.OrderAccepted(order));
        }

        public Task OrderStateChanged(Order order, OrderState oldState)
        {
            return DelegateRequest(s => s.OrderStateChanged(order, oldState));
        }

        public Task UserSubscribed(User user)
        {
            return DelegateRequest(s => s.UserSubscribed(user));
        }

        public Task UserUnsubscribed(User user)
        {
            return DelegateRequest(s => s.UserUnsubscribed(user));
        }

        public Task SubscriptionReminder(Order order)
        {
            return DelegateRequest(s => s.SubscriptionReminder(order));
        }

        public Task SupportRequested(string senderEmail, string subject, string body)
        {
            return DelegateRequest(s => s.SupportRequested(senderEmail, subject, body));
        }

        public Task PasswordRecovery(User user, string token)
        {
            return DelegateRequest(s => s.PasswordRecovery(user, token));
        }

        public Task PasswordRecoveryAlt(string email)
        {
            return DelegateRequest(s => s.PasswordRecoveryAlt(email));
        }
    }
}
