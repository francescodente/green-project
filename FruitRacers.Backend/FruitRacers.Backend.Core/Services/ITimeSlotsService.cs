using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ITimeSlotsService
    {
        Task<IEnumerable<TimeSlotDto>> GetNextTimeSlots(int daysAhead);

        Task AddTimeSlotOverride(TimeSlotOverrideDto timeSlotOverride);
    }
}
