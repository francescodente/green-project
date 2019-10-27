using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.TimeSlots
{
    public interface ITimeSlotsService
    {
        Task<IEnumerable<TimeSlotDto>> GetNextTimeSlots(int daysAhead);

        Task AddTimeSlotOverride(TimeSlotOverrideDto timeSlotOverride);
    }
}
