using System;

namespace FruitRacers.Backend.Contracts.TimeSlots
{
    public class TimeSlotWithCapacityDto
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int ActualCapacity { get; set; }
        public int DefaultCapacity { get; set; }
        public int OrdersCount { get; set; }
        public int Overrides { get; set; }
    }
}
