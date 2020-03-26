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
            return this.mailService.NewMail() // TODO: Setup real mail contexts and use those instead of the test one
                .From(MailContext.Test)
                .To(request.SenderEmail)
                .Subject(request.Subject)
                .Body(request.Body)
                .Send();
        }
    }
}
