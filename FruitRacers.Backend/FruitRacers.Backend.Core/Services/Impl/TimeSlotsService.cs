using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
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

        public async Task<IEnumerable<TimeSlotDto>> GetNextTimeSlots(int daysAhead)
        {
            return await this.Session
                .TimeSlots
                .GetAllWithActualCapacities(DateTime.Today, daysAhead)
                .Then(ts => ts.Select(t => this.CreateTimeSlotDto(t.Slot, t.Capacity, t.Date)));
        }

        private TimeSlotDto CreateTimeSlotDto(TimeSlot slot, int actualCapacity, DateTime date)
        {
            TimeSlotDto timeSlotDto = this.Mapper.Map(slot, new TimeSlotDto { Date = date });
            timeSlotDto.SlotCapacity = actualCapacity;
            return timeSlotDto;
        }
    }
}
