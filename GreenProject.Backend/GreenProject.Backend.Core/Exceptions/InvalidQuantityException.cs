using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class InvalidQuantityException : DomainException
    {
        public InvalidQuantityException()
            : base("The given quantity is not valid")
        {
        }

        public override string MainErrorCode => ErrorCodes.Orders.InvalidQuantity;
    }
}
