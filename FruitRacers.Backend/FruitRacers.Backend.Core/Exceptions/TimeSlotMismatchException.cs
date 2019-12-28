using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class TimeSlotMismatchException : DomainException
    {
        public TimeSlotMismatchException(TimeSlot timeSlot, DateTime date)
            : base(string.Format("Mismatched day of week between the specified time slot ({0}) and date ({1})",
                timeSlot.Weekday, date.DayOfWeek))
        {
        }
    }
}
