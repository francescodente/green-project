using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Utils.Session;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FruitRacers.Backend.ApiLayer.Utils
{
    public class UserSession : IUserSession
    {
        private readonly HttpContext context;

        public bool IsLoggedIn => this.context.User.Identity.IsAuthenticated;

        public int UserId => int.Parse(this.context.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public IEnumerable<RoleType> Roles => this.context
            .User
            .Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => Enum.Parse(typeof(RoleType), c.Value))
            .Cast<RoleType>();

        public UserSession(IHttpContextAccessor contextAccessor)
        {
            this.context = contextAccessor.HttpContext;
        }

        public bool HasRole(RoleType role)
        {
            return this.context.User.IsInRole(role.ToString());
        }
    }
}
