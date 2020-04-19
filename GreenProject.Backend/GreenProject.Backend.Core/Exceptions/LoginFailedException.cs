using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

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
