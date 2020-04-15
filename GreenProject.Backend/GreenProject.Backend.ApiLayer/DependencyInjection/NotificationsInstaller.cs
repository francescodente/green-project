using GreenProject.Backend.ApiLayer.HostedServices;
using GreenProject.Backend.Core.Utils.Email;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Infrastructure.Notifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class NotificationsInstaller : IServiceInstaller
    {
        private const string TEMPLATES_FOLDER = "MailTemplates";

        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services
                .AddSingleton(this.CreateNotificationsService)
                .AddHostedService<NotificationsDaemon>();
        }

        private INotificationsService CreateNotificationsService(IServiceProvider provider)
        {
            ICollection<INotificationsService> subServices = new List<INotificationsService>();

            //subServices.Add(this.CreateMailNotificationsService(provider));

            return new CompositeNotificationsService(subServices);
        }

        private INotificationsService CreateMailNotificationsService(IServiceProvider provider)
        {
            string contentRoot = provider.GetRequiredService<IWebHostEnvironment>().WebRootPath;
            string basePath = Path.Combine(contentRoot, TEMPLATES_FOLDER);

            return new MailNotifications(
                provider.GetRequiredService<IMailService>(),
                basePath,
                provider.GetRequiredService<MailNotificationsSettings>());
        }
    }
}
