﻿using GreenProject.Backend.Core.Utils.Notifications;
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

        private Task DelegateRequest(Func<INotificationsService, Task> notification)
        {
            return Task.WhenAll(this.services.Select(notification));
        }

        public Task OrderAccepted(Order order)
        {
            return this.DelegateRequest(s => s.OrderAccepted(order));
        }

        public Task OrderReceived(Order order)
        {
            return this.DelegateRequest(s => s.OrderReceived(order));
        }

        public Task OrderStateChanged(Order order, OrderState oldState)
        {
            return this.DelegateRequest(s => s.OrderStateChanged(order, oldState));
        }

        public Task UserSubscribed(User user)
        {
            return this.DelegateRequest(s => s.UserSubscribed(user));
        }

        public Task UserUnsubscribed(User user)
        {
            return this.DelegateRequest(s => s.UserUnsubscribed(user));
        }

        public Task WeeklyOrderReminder(User user)
        {
            return this.DelegateRequest(s => s.WeeklyOrderReminder(user));
        }
    }
}