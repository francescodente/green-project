using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface ITimeSlotRepository : IReadOnlyRepository<TimeSlot>
    {
        void InsertOverride(TimeSlotOverride timeSlotOverride);
    }
}
