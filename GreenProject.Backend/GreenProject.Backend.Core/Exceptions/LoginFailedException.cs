using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class LoginFailedException : DomainException
    {
        public LoginFailedException()
            : base("Unable to login")
        {

        }

        public override string MainErrorCode => ErrorCodes.Auth.LoginFailed;
    }
}
