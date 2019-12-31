using AutoMapper;
using FruitRacers.Backend.Contracts;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class SupportService : AbstractService, ISupportService
    {
        private readonly IMailService mailService;

        public SupportService(IRequestSession request, IMapper mapper, IMailService mailService)
            : base(request, mapper)
        {
            this.mailService = mailService;
        }

        public async Task SendSupportEmail(SupportRequestDto request)
        {
            await this.mailService.NewMail()
                .From(MailContext.Test)
                .To(request.SenderEmail)
                .Subject(request.Subject)
                .Body(request.Body)
                .Send();
        }
    }
}
