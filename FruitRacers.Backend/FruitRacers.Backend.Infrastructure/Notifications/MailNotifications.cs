using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Core.Utils.Email;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Infrastructure.Notifications
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

        public async Task OrderReceived(OrderSection order)
        {
            await this.SendMailNotification(
                this.settings.OrderReceived,
                MailTemplates.OrderReceived(order),
                order.Supplier.User.Email);
        }

        public async Task SupplierRegistered(User supplier, string generatedPassword)
        {
            await this.SendMailNotification(
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

        private async Task<string> LoadMailTemplate(MailNotificationDescription description)
        {
            string path = Path.Combine(this.baseTemplatePath, description.BodyTemplateFile);
            return await File.ReadAllTextAsync(path);
        }
    }
}
