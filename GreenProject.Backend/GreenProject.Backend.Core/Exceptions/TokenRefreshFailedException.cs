using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class TokenRefreshFailedException : DomainException
    {
        public TokenRefreshFailedException()
            : base("Unable to refresh the given token")
        {
        }

        public override string MainErrorCode => ErrorCodes.Auth.RefreshFailed;
    }
}
