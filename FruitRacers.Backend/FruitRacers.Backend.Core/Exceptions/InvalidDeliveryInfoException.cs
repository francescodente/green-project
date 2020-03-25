using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class InvalidDeliveryInfoException : DomainException
    {
        private InvalidDeliveryInfoException(string message)
            : base(message)
        {

        }

        public static InvalidDeliveryInfoException WithMessage(string message)
        {
            return new InvalidDeliveryInfoException(message);
        }

        public static InvalidDeliveryInfoException PastDate()
        {
            return WithMessage("Unable to set a past date as delivery date");
        }

        public static InvalidDeliveryInfoException MissingTimeSlot()
        {
            return WithMessage("Missing time slot for the delivery");
        }

        public static InvalidDeliveryInfoException WeekdayMismatch()
        {
            return WithMessage("There was a mismatch between the time slot and the delivery date's day of week");
        }

        public static InvalidDeliveryInfoException TimeSlotFull()
        {
            return WithMessage("The selected time slot is already full");
        }
    }
}
