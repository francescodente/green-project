using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface ITimeSlotRepository : IReadOnlyRepository<TimeSlot>
    {
        ITimeSlotRepository IncludingOverrides(DateTime startDate, DateTime finishDate);
    }
}
