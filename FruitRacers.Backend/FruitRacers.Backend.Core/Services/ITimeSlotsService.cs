using FruitRacers.Backend.Contracts.TimeSlots;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ITimeSlotsService
    {
        Task<IEnumerable<DailyTimeTable>> GetNextTimeSlots(int daysAhead);

        Task AddTimeSlotOverride(TimeSlotOverrideDto timeSlotOverride);
    }
}
