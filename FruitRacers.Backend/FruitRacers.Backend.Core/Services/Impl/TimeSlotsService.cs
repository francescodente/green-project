using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class TimeSlotsService : AbstractService, ITimeSlotsService
    {
        public TimeSlotsService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
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

            await this.Data.SaveChanges();
        }

        public async Task<IEnumerable<DailyTimeTable>> GetNextTimeSlots(int daysAhead)
        {
            DateTime startDate = DateTime.Today.AddDays(1);
            DateTime finishDate = startDate.AddDays(daysAhead - 1);

            IEnumerable<TimeSlot> timeSlots = await this.Data
                .TimeSlots
                .IncludingOverrides(startDate, finishDate)
                .AsEnumerable();

            IEnumerable<Order> orders = await this.Data
                .Orders
                .AfterDate(startDate)
                .BeforeDate(finishDate)
                .WithState(OrderState.Confirmed)
                .AsEnumerable();

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
