using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class ConfirmationFailedException : DomainException
    {
        public override string MainErrorCode => ErrorCodes.Auth.ConfirmationFailed;

        public ConfirmationFailedException()
            : base("Email confirmation failed")
        {

        }
    }
}
