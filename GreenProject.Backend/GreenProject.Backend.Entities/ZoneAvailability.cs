using System;

namespace GreenProject.Backend.Entities
{
    public class ZoneAvailability
    {
        public string ZipCode { get; set; }
        public DayOfWeek Day { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual Availability Availability { get; set; }
    }
}
