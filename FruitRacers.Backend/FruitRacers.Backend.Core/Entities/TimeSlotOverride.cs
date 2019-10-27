using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class TimeSlotOverride
    {
        public DateTime Date { get; set; }
        public int TimeSlotId { get; set; }
        public int Offset { get; set; }

        public virtual TimeSlot TimeSlot { get; set; }
    }
}
