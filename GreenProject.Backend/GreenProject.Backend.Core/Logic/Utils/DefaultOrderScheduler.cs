using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
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
        private readonly IDataSession data;

        public DefaultOrderScheduler(IDataSession data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<DateTime>> EnumerateAvailableDates(DateTime startingDate, string zipCode)
        {
            IDictionary<DateTime, int> orderCountsByDate = await data
                .Orders
                .Where(o => o.DeliveryDate >= startingDate)
                .Where(o => o.OrderState != OrderState.Canceled)
                .GroupBy(o => o.DeliveryDate, (date, orders) => new { Date = date, Orders = orders.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Orders);

            IDictionary<DayOfWeek, int> availabilities = await this.data
                .ZoneAvailabilities
                .Where(z => z.ZipCode == zipCode)
                .Select(z => z.Availability)
                .ToDictionaryAsync(a => a.Day, a => a.AvailableSlots);

            if (availabilities.Count == 0)
            {
                throw new InvalidOperationException("Zone with no availabilities in the database");
            }

            return EnumerableUtils.Iterate(startingDate, d => d.AddDays(1))
                .Where(d => availabilities.ContainsKey(d.DayOfWeek))
                .Where(d => availabilities[d.DayOfWeek] - orderCountsByDate.GetValueAsOptional(d).OrElse(0) > 0);
        }

        public Task<DateTime> FindNextAvailableDate(DateTime startingDate, string zipCode)
        {
            return this.EnumerateAvailableDates(startingDate, zipCode).Map(d => d.First());
        }
    }
}
