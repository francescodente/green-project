using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException(string message)
            : base(message)
        {

        }

        public static UserNotFoundException WithId(int userId)
        {
            return new UserNotFoundException(string.Format("Unable to find user with id {0}", userId));
        }

        public static UserNotFoundException WithEmail(string email)
        {
            return new UserNotFoundException(string.Format("Unable to find user with email {0}", email));
        }
    }
}
