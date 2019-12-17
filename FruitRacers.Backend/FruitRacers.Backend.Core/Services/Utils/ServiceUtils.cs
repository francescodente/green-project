using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Utils
{
    public static class ServiceUtils
    {
        public static void EnsureOwnership(int resourceOwnerId, int userId)
        {
            if (resourceOwnerId != userId)
            {
                throw new UnauthorizedUserAccessException(userId);
            }
        }
    }
}
