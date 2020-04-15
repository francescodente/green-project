using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public class CompositeNotificationsService : INotificationsService
    {
        private readonly IEnumerable<INotificationsService> services;

        public CompositeNotificationsService(IEnumerable<INotificationsService> services)
        {
            this.services = services;
        }

        public Task OrderReceived(Order order)
        {
            return Task.WhenAll(this.services.Select(s => s.OrderReceived(order)));
        }

        public Task OrderStateChanged(Order order, OrderState oldState)
        {
            return Task.WhenAll(this.services.Select(s => s.OrderStateChanged(order, oldState)));
        }
    }
}
