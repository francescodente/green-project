﻿using FruitRacers.Backend.Contracts.Support;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils.Email;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class SupportService : AbstractService, ISupportService
    {
        private readonly IMailService mailService;

        public SupportService(IRequestSession request, IMailService mailService)
            : base(request)
        {
            this.mailService = mailService;
        }

        public async Task SendSupportEmail(SupportRequestDto request)
        {
            await this.mailService.NewMail() // TODO: Setup real mail contexts and use those instead of the test one
                .From(MailContext.Test)
                .To(request.SenderEmail)
                .Subject(request.Subject)
                .Body(request.Body)
                .Send();
        }
    }
}
