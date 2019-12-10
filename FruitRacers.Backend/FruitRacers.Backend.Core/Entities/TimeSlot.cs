using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class TimeSlot
    {
        public TimeSlot()
        {
            Orders = new HashSet<Order>();
            TimeSlotOverrides = new HashSet<TimeSlotOverride>();
        }

        public int TimeSlotId { get; set; }
        public int Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int SlotCapacity { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<TimeSlotOverride> TimeSlotOverrides { get; set; }
    }
}
