using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace GreenProject.Backend.ApiLayer.Utils
{
    public class UserSession : IUserSession
    {
        private readonly HttpContext _context;

        public bool IsLoggedIn => _context.User.Identity.IsAuthenticated;

        public int UserId => int.Parse(_context.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public IEnumerable<RoleType> Roles => _context
            .User
            .Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => Enum.Parse(typeof(RoleType), c.Value))
            .Cast<RoleType>();

        public UserSession(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }

        public bool HasRole(RoleType role)
        {
            return _context.User.IsInRole(role.ToString());
        }
    }
}
