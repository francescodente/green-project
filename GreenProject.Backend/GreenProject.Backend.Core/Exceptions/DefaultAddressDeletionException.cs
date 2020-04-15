using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class DefaultAddressDeletionException : DomainException
    {
        public DefaultAddressDeletionException()
            : base("Unable to remove the default address if the user is subscribed to weekly orders")
        {
        }

        public override string MainErrorCode => ErrorCodes.Addresses.DeletingDefaultAddress;


    }
}
