using GreenProject.Backend.Contracts.Support;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Email;
using GreenProject.Backend.Core.Utils.Session;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class SupportService : AbstractService, ISupportService
    {
        private readonly IMailService mailService;

        public SupportService(IRequestSession request, IMailService mailService)
            : base(request)
        {
            this.mailService = mailService;
        }

        public Task SendSupportEmail(SupportRequestDto request)
        {
            return this.mailService.NewMail()
                .From(MailContext.Support)
                .To(MailContext.Administrators)
                .Subject(request.Subject)
                .Body(request.Body)
                .Send();
        }
    }
}
