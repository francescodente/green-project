using GreenProject.Backend.Core.Utils.Email;
using GreenProject.Backend.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class MailServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IMailService, MailService>();
        }
    }
}
