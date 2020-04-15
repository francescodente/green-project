using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class MissingPurchasePermissionException : DomainException
    {
        public MissingPurchasePermissionException()
            : base("Purchase permission is required")
        {
        }

        public override string MainErrorCode => ErrorCodes.Auth.MissingPermission;
    }
}
