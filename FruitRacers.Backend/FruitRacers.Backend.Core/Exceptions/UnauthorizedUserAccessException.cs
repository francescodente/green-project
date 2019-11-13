using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class UnauthorizedUserAccessException : Exception
    {
        public UnauthorizedUserAccessException(int expectedId, int actualId)
            : base(string.Format("Unauthorized access from user({0}) to data belonging to user({1})", actualId, expectedId))
        {

        }
    }
}
