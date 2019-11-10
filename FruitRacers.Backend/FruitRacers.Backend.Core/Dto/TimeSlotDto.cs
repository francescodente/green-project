using System;

namespace FruitRacers.Backend.Core.Dto
{
    public class TimeSlotDto
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int SlotCapacity { get; set; }
    }
}
