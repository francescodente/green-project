using FluentEmail.Core;
using FluentEmail.MailKitSmtp;
using FluentEmail.Smtp;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class FluentMailNotifications : INotificationsService
    {
        private readonly IFluentEmailFactory emailFactory;
        private readonly MailSettings settings;

        public FluentMailNotifications(IFluentEmailFactory emailFactory, MailSettings settings)
        {
            this.emailFactory = emailFactory;
            this.settings = settings;
        }

        private IFluentEmail FromNotificationType<T>(NotificationType notificationType, T model)
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

            return email
                .SetFrom(addressInfo.Address, addressInfo.DisplayName)
                .Subject(description.Subject)
                .UsingTemplateFromFile(description.BodyTemplateFile, model);
        }

        public Task AccountConfirmation(User user)
        {
            var model = new { User = user, this.settings.WebRoot };

            return this.FromNotificationType(NotificationType.AccountConfirmation, model)
                .To(user.Email)
                .SendAsync()
                .Then(response =>
                {
                    if (!response.Successful)
                    {
                        throw new Exception(response.ErrorMessages.ConcatStrings(";"));
                    }
                });
        }

        public Task OrderAccepted(Order order)
        {
            var model = new { Order = order };

            return this.FromNotificationType(NotificationType.OrderSummary, model)
                .To(order.User.Email)
                .SendAsync();
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

            return this.FromNotificationType(type, model)
                .To(order.User.Email)
                .SendAsync();
        }

        public Task SubscriptionReminder(Order order)
        {
            var model = new { Order = order };

            return this.FromNotificationType(NotificationType.SubscriptionReminder, model)
                .To(order.User.Email)
                .SendAsync();
        }

        public Task UserSubscribed(User user)
        {
            var model = new { User = user };

            return this.FromNotificationType(NotificationType.UserSubscribed, model)
                .To(user.Email)
                .SendAsync();
        }

        public Task UserUnsubscribed(User user)
        {
            var model = new { User = user };
            
            return this.FromNotificationType(NotificationType.UserUnsubscribed, model)
                .To(user.Email)
                .SendAsync();
        }

        public Task SupportRequested(string senderEmail, string subject, string body)
        {
            var model = new
            {
                SenderEmail = senderEmail,
                Subject = subject,
                Body = body
            };

            return this.FromNotificationType(NotificationType.SupportRequested, model)
                .To(this.settings.EmailAddresses[MailContext.Support].Address)
                .SendAsync();
        }
    }
}
