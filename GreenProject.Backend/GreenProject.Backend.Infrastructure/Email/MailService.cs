using GreenProject.Backend.Core.Utils.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings settings;

        public MailService(MailSettings settings)
        {
            this.settings = settings;
        }

        public IMailBuilder NewMail()
        {
            return new MailBuilder(this.settings);
        }
    }
}
