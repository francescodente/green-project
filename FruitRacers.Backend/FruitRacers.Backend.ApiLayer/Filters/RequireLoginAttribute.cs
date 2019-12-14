using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.AspNetCore.Authorization;

namespace FruitRacers.Backend.ApiLayer.Filters
{
    public class RequireLoginAttribute : AuthorizeAttribute
    {
        public RequireLoginAttribute(params RoleType[] roles)
            : base()
        {
            if (roles.Length > 0)
            {
                this.Roles = roles.ConcatStrings(",");
            }
        }

        public RequireLoginAttribute(string policy, params RoleType[] roles)
            : this(roles)
        {
            this.Policy = policy;
        }
    }
}
