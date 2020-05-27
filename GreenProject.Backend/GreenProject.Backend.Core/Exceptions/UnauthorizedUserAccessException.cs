using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class UnauthorizedUserAccessException : DomainException
    {
        public UnauthorizedUserAccessException()
            : base("Unauthorized access to protected resources")
        {

        }

        public override string MainErrorCode => ErrorCodes.Auth.UnauthorizedAccess;
    }
}
