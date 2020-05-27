using GreenProject.Backend.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.HostedServices
{
    public class NotificationsDaemon : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly NotificationsDaemonSettings _settings;

        public NotificationsDaemon(IServiceScopeFactory scopeFactory, NotificationsDaemonSettings settings)
        {
            _scopeFactory = scopeFactory;
            _settings = settings;
        }

        public void Dispose()
        {
            if (_settings.IsEnabled)
            {
                _timer.Dispose();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_settings.IsEnabled)
            {
                _timer = new Timer(_ => OnTick(), null, _settings.InitialDelay, _settings.Period);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_settings.IsEnabled)
            {
                _timer.Change(Timeout.Infinite, 0);
            }

            return Task.CompletedTask;
        }

        private async void OnTick()
        {
            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                IReminderService reminderService = scope.ServiceProvider.GetRequiredService<IReminderService>();

                await reminderService.CheckSubscriptionReminders(_settings.SubscriptionReminderTime);
            }
        }
    }
}
