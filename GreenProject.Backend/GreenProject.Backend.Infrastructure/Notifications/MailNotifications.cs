using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Utils.Email;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Shared.Utils;
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

        public Task OrderReceived(OrderSection order)
        {
            return this.SendMailNotification(
                this.settings.OrderReceived,
                MailTemplates.OrderReceived(order),
                order.Supplier.User.Email);
        }

        public Task SupplierRegistered(User supplier, string generatedPassword)
        {
            return this.SendMailNotification(
                this.settings.SupplierRegistered,
                MailTemplates.SupplierRegistered(supplier, generatedPassword),
                supplier.Email);
        }

        private async Task SendMailNotification(MailNotificationDescription description, Func<string, string> templateModifier, params string[] recipients)
        {
            string bodyTemplate = await this.LoadMailTemplate(description);

            IMailBuilder builder = this.mailService.NewMail()
                .From(description.Context)
                .Subject(description.Subject)
                .BodyHtml(templateModifier(bodyTemplate));
            recipients.ForEach(r => builder.To(r));

            await builder.Send();
        }

        private Task<string> LoadMailTemplate(MailNotificationDescription description)
        {
            string path = Path.Combine(this.baseTemplatePath, description.BodyTemplateFile);
            return File.ReadAllTextAsync(path);
        }
    }
}
