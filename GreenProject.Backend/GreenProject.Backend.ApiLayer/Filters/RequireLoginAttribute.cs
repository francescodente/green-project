using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class RequireLoginAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IEnumerable<string> _roles;

        public RequireLoginAttribute(params RoleType[] roles)
        {
            _roles = roles.Select(r => r.ToString());
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsPrincipal user = context.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            if (!_roles.Any() || _roles.Any(user.IsInRole))
            {
                return;
            }
            context.Result = new ForbidResult();
        }
    }
}
