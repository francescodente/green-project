using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class MissingDeliveryInfoException : DomainException
    {
        public MissingDeliveryInfoException()
            : base("Unable to confirm the order because some information for the delivery are missing")
        {

        }
    }
}
