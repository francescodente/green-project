using FluentEmail.Core;
using FluentEmail.MailKitSmtp;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using RazorLight;
using System;
using System.Dynamic;
using System.Globalization;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class FluentMailNotifications : INotificationsService
    {
        private readonly IFluentEmailFactory _emailFactory;
        private readonly IRazorLightEngine _razorEngine;
        private readonly MailSettings _settings;

        public FluentMailNotifications(IFluentEmailFactory emailFactory, IRazorLightEngine razorEngine, MailSettings settings)
        {
            _emailFactory = emailFactory;
            _razorEngine = razorEngine;
            _settings = settings;
        }

        private async Task SendNotification<T>(NotificationType notificationType, T model, string recipient)
        {
            MailDescription description = _settings.EmailDescriptions[notificationType];
            MailAddressInfo addressInfo = _settings.EmailAddresses[description.Context];

            IFluentEmail email = _emailFactory.Create();

            email.Sender = new MailKitSender(new SmtpClientOptions
            {
                Server = _settings.Host,
                Port = _settings.Port,
                Password = addressInfo.Password,
                User = addressInfo.Address,
                UseSsl = true,
                RequiresAuthentication = true
            });

            dynamic viewBag = new ExpandoObject();
            viewBag.WebRoot = _settings.WebRoot;
            viewBag.Title = description.Title;
            viewBag.EmailContent = description.BodyTemplateFile;
            viewBag.CultureInfo = CultureInfo.GetCultureInfo(_settings.CultureInfo);

            string body = await _razorEngine.CompileRenderAsync(_settings.MailLayoutKey, model, viewBag);

            await email
                .SetFrom(addressInfo.Address, addressInfo.DisplayName)
                .To(recipient)
                .Subject(description.Subject)
                .Body(body, true)
                .SendAsync()
                .Then(result =>
                {
                    if (!result.Successful)
                    {
                        throw new Exception(result.ErrorMessages.ConcatStrings(";"));
                    }
                });
        }

        public Task AccountConfirmation(User user, string token)
        {
            var model = new { User = user, Token = token };

            return SendNotification(NotificationType.AccountConfirmation, model, user.Email);
                
        }

        public Task OrderAccepted(Order order)
        {
            var model = new { Order = order };

            return SendNotification(NotificationType.OrderSummary, model, order.User.Email);
        }

        public Task OrderStateChanged(Order order, OrderState oldState)
        {
            NotificationType type = order.OrderState switch
            {
                OrderState.Shipping => NotificationType.OrderShipped,
                OrderState.Canceled => NotificationType.OrderCanceled,
                OrderState.Completed => NotificationType.OrderCompleted,
                _ => throw new ArgumentException(nameof(order))
            };

            var model = new { Order = order };

            return SendNotification(type, model, order.User.Email);
        }

        public Task SubscriptionReminder(Order order)
        {
            var model = new { Order = order };

            return SendNotification(NotificationType.SubscriptionReminder, model, order.User.Email);
        }

        public Task UserSubscribed(User user)
        {
            var model = new { User = user };

            return SendNotification(NotificationType.UserSubscribed, model, user.Email);
        }

        public Task UserUnsubscribed(User user)
        {
            var model = new { User = user };

            return SendNotification(NotificationType.UserUnsubscribed, model, user.Email);
        }

        public Task SupportRequested(string senderEmail, string subject, string body)
        {
            var model = new
            {
                SenderEmail = senderEmail,
                Subject = subject,
                Body = body
            };

            string recipient = _settings.EmailAddresses[MailContext.Support].Address;

            return SendNotification(NotificationType.SupportRequest, model, recipient);
        }

        public Task PasswordRecovery(User user, string token)
        {
            var model = new { User = user, Token = token };

            return SendNotification(NotificationType.PasswordRecovery, model, user.Email);
        }

        public Task PasswordRecoveryAlt(string email)
        {
            var model = new { Email = email };

            return SendNotification(NotificationType.PasswordRecoveryAlt, model, email);
        }
    }
}
