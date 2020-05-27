using GreenProject.Backend.Contracts.Errors;

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
