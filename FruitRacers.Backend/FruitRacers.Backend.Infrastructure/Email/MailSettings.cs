using FruitRacers.Backend.Core.Utils.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Infrastructure.Email
{
    public class MailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public IDictionary<MailContext, MailAddressInfo> EmailAddresses { get; set; }
    }
}
