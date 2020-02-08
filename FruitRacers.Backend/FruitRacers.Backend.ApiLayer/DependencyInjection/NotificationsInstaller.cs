using FruitRacers.Backend.Core.Utils.Email;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Infrastructure.Notifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class NotificationsInstaller : IServiceInstaller
    {
        private const string TEMPLATES_FOLDER = "MailTemplates";

        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(this.CreateNotificationsService);
        }

        private INotificationsService CreateNotificationsService(IServiceProvider provider)
        {
            string contentRoot = provider.GetRequiredService<IWebHostEnvironment>().ContentRootPath;
            string basePath = Path.Combine(contentRoot, TEMPLATES_FOLDER);

            return new MailNotifications(
                provider.GetRequiredService<IMailService>(),
                basePath,
                provider.GetRequiredService<MailNotificationsSettings>());
        }
    }
}
