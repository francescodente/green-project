using System;

namespace FruitRacers.Backend.Contracts.TimeSlots
{
    public class TimeSlotDto
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
    }
}
