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
        private readonly IFluentEmailFactory emailFactory;
        private readonly IRazorLightEngine razorEngine;
        private readonly MailSettings settings;

        public FluentMailNotifications(IFluentEmailFactory emailFactory, IRazorLightEngine razorEngine, MailSettings settings)
        {
            this.emailFactory = emailFactory;
            this.razorEngine = razorEngine;
            this.settings = settings;
        }

        private async Task SendNotification<T>(NotificationType notificationType, T model, string recipient)
        {
            MailDescription description = this.settings.EmailDescriptions[notificationType];
            MailAddressInfo addressInfo = this.settings.EmailAddresses[description.Context];

            IFluentEmail email = this.emailFactory.Create();

            email.Sender = new MailKitSender(new SmtpClientOptions
            {
                Server = this.settings.Host,
                Port = this.settings.Port,
                Password = addressInfo.Password,
                User = addressInfo.Address,
                UseSsl = true,
                RequiresAuthentication = true
            });

            dynamic viewBag = new ExpandoObject();
            viewBag.WebRoot = this.settings.WebRoot;
            viewBag.Title = description.Title;
            viewBag.EmailContent = description.BodyTemplateFile;
            viewBag.CultureInfo = CultureInfo.GetCultureInfo(this.settings.CultureInfo);

            string body = await this.razorEngine.CompileRenderAsync(this.settings.MailLayoutKey, model, viewBag);

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

            return this.SendNotification(NotificationType.AccountConfirmation, model, user.Email);
                
        }

        public Task OrderAccepted(Order order)
        {
            var model = new { Order = order };

            return this.SendNotification(NotificationType.OrderSummary, model, order.User.Email);
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

            return this.SendNotification(type, model, order.User.Email);
        }

        public Task SubscriptionReminder(Order order)
        {
            var model = new { Order = order };

            return this.SendNotification(NotificationType.SubscriptionReminder, model, order.User.Email);
        }

        public Task UserSubscribed(User user)
        {
            var model = new { User = user };

            return this.SendNotification(NotificationType.UserSubscribed, model, user.Email);
        }

        public Task UserUnsubscribed(User user)
        {
            var model = new { User = user };

            return this.SendNotification(NotificationType.UserUnsubscribed, model, user.Email);
        }

        public Task SupportRequested(string senderEmail, string subject, string body)
        {
            var model = new
            {
                SenderEmail = senderEmail,
                Subject = subject,
                Body = body
            };

            string recipient = this.settings.EmailAddresses[MailContext.Support].Address;

            return this.SendNotification(NotificationType.SupportRequest, model, recipient);
        }

        public Task PasswordRecovery(User user, string token)
        {
            var model = new { User = user, Token = token };

            return this.SendNotification(NotificationType.PasswordRecovery, model, user.Email);
        }

        public Task PasswordRecoveryAlt(string email)
        {
            var model = new { Email = email };

            return this.SendNotification(NotificationType.PasswordRecoveryAlt, model, email);
        }
    }
}
