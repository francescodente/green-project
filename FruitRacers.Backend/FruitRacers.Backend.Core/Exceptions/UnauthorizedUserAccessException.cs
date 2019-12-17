using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class UnauthorizedUserAccessException : DomainException
    {
        public UnauthorizedUserAccessException(int userId)
            : base(string.Format("Unauthorized access from user with id {0} to resources belonging to another user", userId))
        {

        }
    }
}
