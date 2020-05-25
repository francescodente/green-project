using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ReminderService : AbstractService, IReminderService
    {
        public ReminderService(IRequestSession request)
            : base(request)
        {

        }

        public async Task CheckSubscriptionReminders(TimeSpan anticipationTime)
        {
            DateTime limit = DateTime.Now + anticipationTime;
            IEnumerable<Order> ordersToBeNotified = await Data
                .Orders
                .Where(o => o.IsSubscription)
                .Where(o => !o.WasReminded)
                .Where(o => limit >= o.DeliveryDate)
                .Where(o => o.OrderState == OrderState.Pending)
                .Include(o => o.User)
                    .ThenInclude(u => u.Person)
                .Include(o => o.Address)
                    .ThenInclude(a => a.Zone)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                        .ThenInclude(i => i.Image)
                .ToArrayAsync();

            await Task.WhenAll(ordersToBeNotified.Select(SendReminder));
            await Data.SaveChangesAsync();
        }

        private Task SendReminder(Order order)
        {
            return Notifications.SubscriptionReminder(order)
                .Then(() => order.WasReminded = true);
        }
    }
}
