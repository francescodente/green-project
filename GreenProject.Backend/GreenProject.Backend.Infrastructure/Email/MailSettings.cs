using GreenProject.Backend.Core.Utils.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Email
{
    public class MailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public IDictionary<MailContext, MailAddressInfo> EmailAddresses { get; set; }
    }
}
