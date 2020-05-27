using System;

namespace GreenProject.Backend.ApiLayer.HostedServices
{
    public class NotificationsDaemonSettings
    {
        public TimeSpan Period { get; set; }
        public TimeSpan InitialDelay { get; set; }
        public bool IsEnabled { get; set; }
        public TimeSpan SubscriptionReminderTime { get; set; }
    }
}
