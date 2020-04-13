using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Session
{
    public interface IUserSession
    {
        bool IsLoggedIn { get; }
        int UserId { get; }
        IEnumerable<RoleType> Roles { get; }

        bool HasRole(RoleType role);
    }
}
