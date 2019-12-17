using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface ITimeSlotRepository : IReadOnlyRepository<TimeSlot>
    {
        void InsertOverride(TimeSlotOverride timeSlotOverride);

        Task<(TimeSlot Slot, int ActualCapacity)> GetActualCapacity(int timeSlotID, DateTime date);

        Task<IEnumerable<(DateTime Date, TimeSlot Slot, int Capacity)>> GetAllWithActualCapacities(DateTime start, int daysCount);
    }
}
