using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.TimeSlots
{
    public class DailyTimeTable
    {
        public DateTime Date { get; set; }
        public IEnumerable<TimeSlotWithCapacityDto> TimeSlots { get; set; }
    }
}
