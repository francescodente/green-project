using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class AlreadySubscribedException : DomainException
    {
        public AlreadySubscribedException()
            : base("User is already subscribed")
        {
        }

        public override string MainErrorCode => ErrorCodes.WeeklyOrders.AlreadySubscribed;
    }
}
