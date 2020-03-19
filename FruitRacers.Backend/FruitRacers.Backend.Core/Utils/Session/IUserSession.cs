using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Session
{
    public interface IUserSession
    {
        bool IsLoggedIn { get; }
        int UserId { get; }
        IEnumerable<RoleType> Roles { get; }

        bool HasRole(RoleType role);
    }
}
