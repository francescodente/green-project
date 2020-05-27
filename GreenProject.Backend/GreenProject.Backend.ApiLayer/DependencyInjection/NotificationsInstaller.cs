using FluentEmail.Core;
using GreenProject.Backend.ApiLayer.HostedServices;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Infrastructure.Notifications;
using GreenProject.Backend.Infrastructure.Notifications.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class NotificationsInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddFluentEmail(null);

            services.AddSingleton<IRazorLightEngine>(_ =>
                new RazorLightEngineBuilder()
                    .UseMemoryCachingProvider()
                    .UseFileSystemProject(Path.Combine(env.ContentRootPath, "MailTemplates"))
                    .Build());

            services
                .AddSingleton(CreateNotificationsService)
                .AddHostedService<NotificationsDaemon>();
        }

        private INotificationsService CreateNotificationsService(IServiceProvider provider)
        {
            ICollection<INotificationsService> subServices = new List<INotificationsService>
            {
                CreateMailNotificationsService(provider)
            };

            return new CompositeNotificationsService(subServices);
        }

        private INotificationsService CreateMailNotificationsService(IServiceProvider provider)
        {
            return new FluentMailNotifications(
                provider.GetRequiredService<IFluentEmailFactory>(),
                provider.GetRequiredService<IRazorLightEngine>(),
                provider.GetRequiredService<MailSettings>());
        }
    }
}
