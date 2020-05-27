using System.Collections.Generic;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class MailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string WebRoot { get; set; }
        public string MailLayoutKey { get; set; }
        public string CultureInfo { get; set; }
        public IDictionary<MailContext, MailAddressInfo> EmailAddresses { get; set; }
        public IDictionary<NotificationType, MailDescription> EmailDescriptions { get; set; }
    }
}
