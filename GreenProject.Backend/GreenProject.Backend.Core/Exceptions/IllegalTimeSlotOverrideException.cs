using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class IllegalTimeSlotOverrideException : DomainException
    {
        public IllegalTimeSlotOverrideException()
            : base("Unable to modify capacity for the given time slot")
        {

        }
    }
}
