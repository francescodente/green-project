using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.TimeSlots
{
    public abstract class AbstractTimeSlotDto
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
    }
}
