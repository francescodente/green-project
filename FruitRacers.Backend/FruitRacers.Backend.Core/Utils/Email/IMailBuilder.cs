using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Email
{
    public interface IMailBuilder
    {
        IMailBuilder To(string address);

        IMailBuilder To(MailContext context);

        IMailBuilder From(MailContext context);

        IMailBuilder Subject(string subject);

        IMailBuilder Body(string body);

        IMailBuilder BodyHtml(string body);

        IMailBuilder Cc(string address);

        Task Send();
    }
}
