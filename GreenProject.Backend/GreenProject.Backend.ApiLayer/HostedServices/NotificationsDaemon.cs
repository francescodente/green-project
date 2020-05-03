using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.HostedServices
{
    public class NotificationsDaemon : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly NotificationsDaemonSettings settings;
        private readonly ILogger logger;

        public NotificationsDaemon(IServiceScopeFactory scopeFactory, NotificationsDaemonSettings settings, ILogger<NotificationsDaemon> logger)
        {
            this.scopeFactory = scopeFactory;
            this.settings = settings;
            this.logger = logger;
        }

        public void Dispose()
        {
            if (this.settings.IsEnabled)
            {
                this.timer.Dispose();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (this.settings.IsEnabled)
            {
                this.timer = new Timer(_ => this.OnTick(), null, this.settings.InitialDelay, this.settings.Period);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (this.settings.IsEnabled)
            {
                this.timer.Change(Timeout.Infinite, 0);
            }

            return Task.CompletedTask;
        }

        private async void OnTick()
        {
            using (IServiceScope scope = this.scopeFactory.CreateScope())
            {
                IReminderService reminderService = scope.ServiceProvider.GetRequiredService<IReminderService>();

                await reminderService.CheckSubscriptionReminders(this.settings.SubscriptionReminderTime);
            }
        }
    }
}
