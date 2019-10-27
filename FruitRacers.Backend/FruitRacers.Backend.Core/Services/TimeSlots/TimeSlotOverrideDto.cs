using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.TimeSlots
{
    public class TimeSlotOverrideDto
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public int Offset { get; set; }
    }
}
