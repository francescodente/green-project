﻿using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Session;
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
            this.timer.Dispose();
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
                IDataSession data = scope.ServiceProvider.GetRequiredService<IDataSession>();
                INotificationsService notifications = scope.ServiceProvider.GetRequiredService<INotificationsService>();

                await this.SendAvailableNotifications(data, notifications);
            }
        }

        private async Task SendAvailableNotifications(IDataSession data, INotificationsService notifications)
        {
            // TODO: implement real notifications
            int id = await data.Users
                .Select(u => u.UserId)
                .FirstAsync();

            this.logger.LogInformation("Sending mail notifications to {id}", id);
        }
    }
}
