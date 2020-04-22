using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
