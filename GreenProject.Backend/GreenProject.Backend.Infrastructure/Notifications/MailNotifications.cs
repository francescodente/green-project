using GreenProject.Backend.Core.Utils.Email;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public class MailNotifications : INotificationsService
    {
        private readonly IMailService mailService;
        private readonly string baseTemplatePath;
        private readonly MailNotificationsSettings settings;

        public MailNotifications(IMailService mailService, string baseTemplatePath, MailNotificationsSettings settings)
        {
            this.mailService = mailService;
            this.baseTemplatePath = baseTemplatePath;
            this.settings = settings;
        }

        public Task OrderReceived(Order order)
        {
            return this.ApplyTemplateAndSend(
                this.MailTo(MailContext.Suppliers),
                this.settings.OrderReceived,
                MailTemplates.OrderReceived(order));
        }

        public Task OrderStateChanged(Order order, OrderState oldState)
        {
            MailNotificationDescription description = order.OrderState switch
            {
                OrderState.Shipping  => this.settings.OrderShipped,
                OrderState.Completed => this.settings.OrderCompleted,
                OrderState.Canceled  => this.settings.OrderCanceled,
                _ => throw new ArgumentException(nameof(oldState))
            };

            return this.ApplyTemplateAndSend(
                this.MailTo(order.User.Email),
                description,
                MailTemplates.OrderStateChanged(order));
        }

        private async Task ApplyTemplateAndSend(
            IMailBuilder mail,
            MailNotificationDescription description,
            Func<string, string> templateModifier)
        {
            string bodyTemplate = await this.LoadMailTemplate(description);

            await mail
                .From(description.Context)
                .Subject(description.Subject)
                .BodyHtml(templateModifier(bodyTemplate))
                .Send();
        }

        private Task<string> LoadMailTemplate(MailNotificationDescription description)
        {
            string path = Path.Combine(this.baseTemplatePath, description.BodyTemplateFile);
            return File.ReadAllTextAsync(path);
        }

        private IMailBuilder MailTo(string recipientAddress)
        {
            return this.mailService.NewMail().To(recipientAddress);
        }

        private IMailBuilder MailTo(MailContext recipientContext)
        {
            return this.mailService.NewMail().To(recipientContext);
        }
    }
}
