using FruitRacers.Backend.Contracts.Support;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Email;
using FruitRacers.Backend.Core.Utils.Session;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
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
