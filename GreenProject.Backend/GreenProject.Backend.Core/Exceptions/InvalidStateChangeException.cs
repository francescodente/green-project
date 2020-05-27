using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Core.Exceptions
{
    public class InvalidStateChangeException : DomainException
    {
        public InvalidStateChangeException(OrderState oldState, OrderState newState)
            : base($"Cannot transition from state {oldState} to {newState}")
        {
        }

        public override string MainErrorCode => ErrorCodes.Orders.InvalidStateTransition;
    }
}
