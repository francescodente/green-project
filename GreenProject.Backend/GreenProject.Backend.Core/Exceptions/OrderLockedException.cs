using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class OrderLockedException : DomainException
    {
        public OrderLockedException()
            : base("Tryng to modify a locked order")
        {
        }

        public override string MainErrorCode => ErrorCodes.Orders.OrderLocked;
    }
}
