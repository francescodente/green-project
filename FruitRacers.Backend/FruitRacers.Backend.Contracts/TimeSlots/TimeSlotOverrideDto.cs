using System;

namespace FruitRacers.Backend.Contracts.TimeSlots
{
    public class TimeSlotOverrideDto
    {
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int Offset { get; set; }
    }
}
