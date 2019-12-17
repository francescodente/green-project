using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class TimeSlotFullException : DomainException
    {
        public TimeSlotFullException(TimeSlot timeSlot, DateTime date)
            : base(string.Format("Unable to place an order for time slot {0}:{1} - {2} because it is already full",
                timeSlot.StartTime,
                timeSlot.FinishTime,
                date.ToString("dd-MM-yyyy")))
        {
            
        }
    }
}
