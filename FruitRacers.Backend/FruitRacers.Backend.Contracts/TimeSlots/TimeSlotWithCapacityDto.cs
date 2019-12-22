using System;

namespace FruitRacers.Backend.Contracts.TimeSlots
{
    public class TimeSlotWithCapacityDto : AbstractTimeSlotDto
    {
        public int ActualCapacity { get; set; }
        public int DefaultCapacity { get; set; }
        public int OrdersCount { get; set; }
        public int Overrides { get; set; }
    }
}
