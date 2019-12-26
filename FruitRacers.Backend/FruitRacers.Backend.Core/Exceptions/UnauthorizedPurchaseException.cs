using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class UnauthorizedPurchaseException : DomainException
    {
        public UnauthorizedPurchaseException()
            : base("Unable to confirm the order because the user is not authorized.")
        {
        }
    }
}
