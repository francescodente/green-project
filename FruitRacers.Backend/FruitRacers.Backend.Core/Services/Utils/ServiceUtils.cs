using FruitRacers.Backend.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Utils
{
    public static class ServiceUtils
    {
        public static void EnsureOwnership(int expectedId, int actualId)
        {
            if (expectedId != actualId)
            {
                throw new UnauthorizedUserAccessException(expectedId, actualId);
            }
        }
    }
}
