using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.TimeSlots;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace GreenProject.Backend.Core.Logic
{
    public class TimeSlotsService : AbstractService, ITimeSlotsService
    {
        public TimeSlotsService(IRequestSession request)
            : base(request)
        {
        }

        public async Task AddTimeSlotOverride(TimeSlotOverrideDto timeSlotOverride)
        {
            (TimeSlot timeSlot, int capacity) = await ServiceUtils.FindTimeSlotWithActualCapacity(
                this.Data, timeSlotOverride.TimeSlotId, timeSlotOverride.Date);

            if (capacity + timeSlotOverride.Offset < 0)
            {
                throw new IllegalTimeSlotOverrideException();
            }

            timeSlot.TimeSlotOverrides
                .SingleOptional()
                .IfElse(
                    o => o.Offset += timeSlotOverride.Offset,
                    () => timeSlot.TimeSlotOverrides.Add(new TimeSlotOverride
                    {
                        Date = timeSlotOverride.Date,
                        Offset = timeSlotOverride.Offset
                    }));

            await this.Data.SaveChangesAsync();
        }

        public async Task<IEnumerable<DailyTimeTable>> GetNextTimeSlots(int daysAhead)
        {
            DateTime startDate = this.DateTime.Today.AddDays(1);
            DateTime finishDate = startDate.AddDays(daysAhead - 1);

            IEnumerable<TimeSlot> timeSlots = await this.Data
                .TimeSlots
                .IncludeFilter(t => t
                    .TimeSlotOverrides
                    .Where(o => o.Date >= startDate && o.Date <= finishDate))
                .ToListAsync();

            IEnumerable<Order> orders = await this.Data
                .Orders
                .Where(o => o.DeliveryDate >= startDate)
                .Where(o => o.DeliveryDate <= finishDate)
                .Where(o => o.OrderState == OrderState.Pending || o.OrderState == OrderState.Completed)
                .ToListAsync();

            IDictionary<(int, DateTime), int> orderCounts = orders
                .GroupBy(o => (o.TimeSlotId.Value, o.DeliveryDate.Value), (td, os) => new { DateAndTimeSlot = td, Count = os.Count() })
                .ToDictionary(x => x.DateAndTimeSlot, x => x.Count);

            IEnumerable<DateTime> dates = EnumerableUtils.Iterate(startDate, d => d.AddDays(1)).Take(daysAhead);

            return dates.GroupJoin(
                timeSlots,
                d => d.DayOfWeek,
                s => s.Weekday,
                (date, slots) => new DailyTimeTable
                {
                    Date = date,
                    TimeSlots = slots.Select(s => this.CreateTimeSlotDtoWithCapacity(
                            s,
                            s.TimeSlotOverrides.Where(o => o.Date.Equals(date)).Select(o => o.Offset).SingleOptional().OrElse(0),
                            orderCounts.GetValueAsOptional((s.TimeSlotId, date)).OrElse(0)))
                        .OrderBy(s => s.StartTime)
                });
        }

        private TimeSlotWithCapacityDto CreateTimeSlotDtoWithCapacity(TimeSlot slot, int overrides, int orders)
        {
            TimeSlotWithCapacityDto timeSlotDto = this.Mapper.Map<TimeSlotWithCapacityDto>(slot);
            timeSlotDto.ActualCapacity = slot.SlotCapacity + overrides - orders;
            timeSlotDto.Overrides = overrides;
            timeSlotDto.OrdersCount = orders;
            timeSlotDto.DefaultCapacity = slot.SlotCapacity;
            return timeSlotDto;
        }
    }
}
