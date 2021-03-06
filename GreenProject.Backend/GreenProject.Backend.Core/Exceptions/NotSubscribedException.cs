using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class NotSubscribedException : DomainException
    {
        public NotSubscribedException()
            : base("Unable to complete the operation because the user is not subscribed")
        {
        }

        public override string MainErrorCode => ErrorCodes.WeeklyOrders.NotSubscribed;
    }
}
