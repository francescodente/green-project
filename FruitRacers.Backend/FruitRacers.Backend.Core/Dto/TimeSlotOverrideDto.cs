using System;

namespace FruitRacers.Backend.Core.Dto
{
    public class TimeSlotOverrideDto
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public int Offset { get; set; }
    }
}
