using FruitRacers.Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RequireLoginAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;

        public RequireLoginAttribute(params UserRole[] roles)
        {
            this.roles = roles.Select(r => r.ToString()).ToArray();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!this.IsAuthorized(context.HttpContext))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool IsAuthorized(HttpContext context)
        {
            if (context.User == null)
            {
                return false;
            }
            return this.roles.Length == 0 || this.roles.Any(context.User.IsInRole);
        }
    }
}
