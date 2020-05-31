using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class NotConfirmedException : DomainException
    {
        public NotConfirmedException()
            : base("Unable to login because the user didn't confirm the email")
        {
        }

        public override string MainErrorCode => ErrorCodes.Auth.NotConfirmed;
    }
}
