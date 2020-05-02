using GreenProject.Backend.Infrastructure.Notifications.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class MailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string WebRoot { get; set; }
        public string MailLayoutKey { get; set; }
        public IDictionary<MailContext, MailAddressInfo> EmailAddresses { get; set; }
        public IDictionary<NotificationType, MailDescription> EmailDescriptions { get; set; }
    }
}
