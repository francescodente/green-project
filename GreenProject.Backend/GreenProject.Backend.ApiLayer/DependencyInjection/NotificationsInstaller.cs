using FluentEmail.Core;
using FluentEmail.Core.Interfaces;
using FluentEmail.MailKitSmtp;
using GreenProject.Backend.ApiLayer.HostedServices;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Infrastructure.Notifications;
using GreenProject.Backend.Infrastructure.Notifications.Mail;
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
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddFluentEmail(null);

            services.AddSingleton<ITemplateRenderer>(new RazorRenderer(typeof(Startup)));

            services
                .AddSingleton(this.CreateNotificationsService)
                .AddHostedService<NotificationsDaemon>();
        }

        private INotificationsService CreateNotificationsService(IServiceProvider provider)
        {
            ICollection<INotificationsService> subServices = new List<INotificationsService>();

            subServices.Add(this.CreateMailNotificationsService(provider));

            return new CompositeNotificationsService(subServices);
        }

        private INotificationsService CreateMailNotificationsService(IServiceProvider provider)
        {
            return new FluentMailNotifications(
                provider.GetRequiredService<IFluentEmailFactory>(),
                provider.GetRequiredService<MailSettings>());
        }
    }
}
