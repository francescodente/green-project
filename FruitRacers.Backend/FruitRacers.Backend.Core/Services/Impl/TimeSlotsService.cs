using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class TimeSlotsService : AbstractService, ITimeSlotsService
    {
        public TimeSlotsService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {
        }

        public async Task AddTimeSlotOverride(TimeSlotOverrideDto timeSlotOverride)
        {
            this.Session.TimeSlots.InsertOverride(this.Mapper.Map<TimeSlotOverride>(timeSlotOverride));
            await this.Session.SaveChanges();
        }

        public async Task<IEnumerable<TimeSlotWithCapacityDto>> GetNextTimeSlots(int daysAhead)
        {
            return await this.Session
                .TimeSlots
                .GetAllWithActualCapacities(DateTime.Today, daysAhead)
                .Then(ts => ts.Select(t => this.CreateTimeSlotDto(t.Slot, t.Capacity, t.Date)));
        }

        private TimeSlotWithCapacityDto CreateTimeSlotDto(TimeSlot slot, int actualCapacity, DateTime date)
        {
            TimeSlotWithCapacityDto timeSlotDto = this.Mapper.Map(slot, new TimeSlotWithCapacityDto { Date = date });
            timeSlotDto.SlotCapacity = actualCapacity;
            return timeSlotDto;
        }
    }
}
