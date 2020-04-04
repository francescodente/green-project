using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Entities
{
    public class Availability
    {
        public Availability()
        {
            Zones = new HashSet<ZoneAvailability>();
        }

        public DayOfWeek Day { get; set; }
        public int AvailableSlots { get; set; }

        public virtual ICollection<ZoneAvailability> Zones { get; set; }
    }
}
