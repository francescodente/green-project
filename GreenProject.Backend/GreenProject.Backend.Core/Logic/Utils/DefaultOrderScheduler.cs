using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public class DefaultOrderScheduler : IOrderScheduler
    {
        public async Task<DateTime> FindNextAvailableDate(IDataSession data, Address address, DateTime startingDate)
        {
            IDictionary<DateTime, int> orderCountsByDate = await data
                .Orders
                .Where(o => o.DeliveryDate >= startingDate)
                .GroupBy(o => o.DeliveryDate, (date, orders) => new { Date = date, Orders = orders.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Orders);

            IDictionary<DayOfWeek, int> availabilities = address.Zone
                .Availabilities
                .ToDictionary(a => a.Day, a => a.Availability.AvailableSlots);

            if (availabilities.Count == 0)
            {
                throw new InvalidOperationException("The given address is currently unreachable from our service");
            }

            return EnumerableUtils.Iterate(startingDate, d => d.AddDays(1))
                .Where(d => availabilities.ContainsKey(d.DayOfWeek))
                .Where(d => availabilities[d.DayOfWeek] - orderCountsByDate.GetValueAsOptional(d).OrElse(0) > 0)
                .First();
        }
    }
}
