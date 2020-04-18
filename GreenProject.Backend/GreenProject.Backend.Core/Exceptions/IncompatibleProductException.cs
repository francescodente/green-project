using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class IncompatibleProductException : DomainException
    {
        public IncompatibleProductException()
            : base("The requested product is incompatible with the given crate")
        {
        }

        public override string MainErrorCode => ErrorCodes.WeeklyOrders.IncompatibleProduct;
    }
}
