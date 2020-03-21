using FruitRacers.Backend.Core.Utils.Email;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Infrastructure.Email
{
    public class MailBuilder : IMailBuilder
    {
        private readonly MailMessage message;
        private readonly SmtpClient smtpClient;
        private readonly MailSettings settings;

        public MailBuilder(MailSettings settings)
        {
            this.smtpClient = new SmtpClient
            {
                Host = settings.Host,
                Port = settings.Port,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            this.message = new MailMessage();
            this.settings = settings;
        }

        public Task Send()
        {
            return this.smtpClient.SendMailAsync(this.message);
        }

        public IMailBuilder To(string address)
        {
            this.message.To.Add(address);
            return this;
        }

        public IMailBuilder To(MailContext context)
        {
            MailAddressInfo info = this.settings.EmailAddresses[context];
            this.message.To.Add(info.Address);
            return this;
        }

        public IMailBuilder From(MailContext context)
        {
            MailAddressInfo info = this.settings.EmailAddresses[context];
            this.smtpClient.Credentials = new NetworkCredential(info.Address, info.Password);
            this.message.From = new MailAddress(info.Address, info.DisplayName);
            return this;
        }

        public IMailBuilder Cc(string address)
        {
            this.message.CC.Add(address);
            return this;
        }

        public IMailBuilder Body(string body)
        {
            this.message.Body = body;
            this.message.IsBodyHtml = false;
            return this;
        }

        public IMailBuilder BodyHtml(string body)
        {
            this.message.Body = body;
            this.message.IsBodyHtml = true;
            return this;
        }

        public IMailBuilder Subject(string subject)
        {
            this.message.Subject = subject;
            return this;
        }
    }
}
