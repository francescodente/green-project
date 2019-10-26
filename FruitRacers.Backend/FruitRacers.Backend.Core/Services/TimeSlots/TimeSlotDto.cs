using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.TimeSlots
{
    public class TimeSlotDto
    {
        public int TimeSlotID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int SlotCapacity { get; set; }
    }
}
