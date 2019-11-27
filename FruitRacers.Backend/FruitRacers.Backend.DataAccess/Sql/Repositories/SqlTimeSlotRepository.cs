using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Z.EntityFramework.Plus;
using System.Threading.Tasks;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlTimeSlotRepository : ReadOnlySqlRepository<TimeSlot>, ITimeSlotRepository
    {
        public SqlTimeSlotRepository(FruitracersContext context)
            : base(context)
        {
        }

        public async Task<int> GetActualCapacity(int timeSlotID, DateTime date)
        {
            Task<int> defaultCapacityTask = this.AsQueryable()
                .Where(s => s.TimeSlotId == timeSlotID)
                .Select(s => s.SlotCapacity)
                .SingleAsync();
            Task<int> ordersCountTask = this.Context
                .Orders
                .Where(o => o.TimeSlotId == timeSlotID)
                .CountAsync();
            Task<int> overridesTask = this.Context
                .TimeSlotOverrides
                .Where(o => o.Date == date && o.TimeSlotId == timeSlotID)
                .SumAsync(o => o.Offset);

            return (await defaultCapacityTask) + (await overridesTask) - (await ordersCountTask);
        }

        public async Task<IEnumerable<(DateTime Date, TimeSlot Slot, int Capacity)>> GetAllWithActualCapacities(DateTime start, int daysCount)
        {
            DateTime finish = start.AddDays(daysCount - 1);

            Task<IEnumerable<TimeSlot>> timeSlotsTask = this.GetTimeSlotsBetweenDates(start, daysCount);
            Task<IDictionary<DateAndTimeSlot, int>> overridesTask = this.GetOverrides(start, finish);
            Task<IDictionary<DateAndTimeSlot, int>> ordersCountTask = this.GetOrdersCount(start, finish);

            IEnumerable<TimeSlot> timeSlots = await timeSlotsTask;
            IDictionary<DateAndTimeSlot, int> overrides = await overridesTask;
            IDictionary<DateAndTimeSlot, int> ordersCount = await ordersCountTask;

            return EnumerableUtils
                .Iterate(start, d => d.AddDays(1))
                .Take(daysCount)
                .Join(timeSlots, d => (int)d.DayOfWeek, t => t.Weekday, (d, t) => new { Date = d, TimeSlot = t })
                .Select(x => (
                    x.Date,
                    x.TimeSlot,
                    x.TimeSlot.SlotCapacity + this.GetCapacityOffset(new DateAndTimeSlot
                    {
                        TimeSlotId = x.TimeSlot.TimeSlotId,
                        Date = x.Date
                    }, overrides, ordersCount)))
                .OrderBy(x => x.Date)
                .ThenBy(x => x.TimeSlot.StartTime);
        }

        private int GetCapacityOffset(DateAndTimeSlot slot, IDictionary<DateAndTimeSlot, int> overrides, IDictionary<DateAndTimeSlot, int> ordersCount)
        {
            int total = 0;
            if (overrides.ContainsKey(slot))
            {
                total += overrides[slot];
            }
            if (ordersCount.ContainsKey(slot))
            {
                total -= ordersCount[slot];
            }
            return total;
        }

        private async Task<IDictionary<DateAndTimeSlot, int>> GetOrdersCount(DateTime start, DateTime finish)
        {
            return await this.Context
                .Orders
                .Where(o => o.OrderState == (int)OrderState.Confirmed)
                .Where(o => o.DeliveryDate >= start && o.DeliveryDate <= finish)
                .GroupBy(
                    o => new { o.DeliveryDate, o.TimeSlotId },
                    (d, os) => new
                    {
                        DateAndTime = new DateAndTimeSlot
                        {
                            Date = d.DeliveryDate.Value,
                            TimeSlotId = d.TimeSlotId.Value
                        },
                        Count = os.Count()
                    })
                .ToDictionaryAsync(x => x.DateAndTime, x => x.Count);
        }

        private async Task<IDictionary<DateAndTimeSlot, int>> GetOverrides(DateTime start, DateTime finish)
        {
            return await this.Context
                .TimeSlotOverrides
                .Where(t => t.Date >= start && t.Date <= finish)
                .GroupBy(
                    t => new { t.Date, t.TimeSlotId },
                    (d, ts) => new
                    {
                        DateAndTime = new DateAndTimeSlot
                        {
                            Date = d.Date,
                            TimeSlotId = d.TimeSlotId
                        },
                        Offset = ts.Sum(t => t.Offset)
                    })
                .ToDictionaryAsync(x => x.DateAndTime, x => x.Offset);
        }

        private async Task<IEnumerable<TimeSlot>> GetTimeSlotsBetweenDates(DateTime start, int daysCount)
        {
            DateTime finish = start.AddDays(daysCount - 1);
            IQueryable<TimeSlot> timeSlots = this.Context.TimeSlots;
            if (daysCount < 7)
            {
                int startDayOfWeek = (int)start.DayOfWeek;
                int finishDayOfWeek = (int)finish.DayOfWeek;
                if (finishDayOfWeek > startDayOfWeek)
                {
                    timeSlots = timeSlots.Where(t => t.Weekday <= finishDayOfWeek && t.Weekday >= startDayOfWeek);
                }
                else
                {
                    timeSlots = timeSlots.Where(t => t.Weekday <= startDayOfWeek || t.Weekday >= finishDayOfWeek);
                }
            }
            return await timeSlots.ToArrayAsync();
        }

        public void InsertOverride(TimeSlotOverride timeSlotOverride)
        {
            this.Context.TimeSlotOverrides.Add(timeSlotOverride);
        }

        private class DateAndTimeSlot : IEquatable<DateAndTimeSlot>
        {
            public DateTime Date { get; set; }
            public int TimeSlotId { get; set; }

            public bool Equals(DateAndTimeSlot other)
            {
                return this.Date.Date == other.Date.Date && this.TimeSlotId == other.TimeSlotId;
            }
        }
    }
}
