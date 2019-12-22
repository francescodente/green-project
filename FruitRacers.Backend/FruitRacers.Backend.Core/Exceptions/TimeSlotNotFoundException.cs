using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class TimeSlotNotFoundException : DomainException
    {
        public TimeSlotNotFoundException(int timeSlotId)
            : base(string.Format("Unable to find time slot with id {0}", timeSlotId))
        {
        }
    }
}
