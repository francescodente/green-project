using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.AspNetCore.Authorization;

namespace FruitRacers.Backend.ApiLayer.Filters
{
    public class RequireLoginAttribute : AuthorizeAttribute
    {
        public RequireLoginAttribute(params UserRole[] roles)
            : base()
        {
            this.Roles = roles.ConcatStrings(",");
        }

        public RequireLoginAttribute(string policy, params UserRole[] roles)
            : this(roles)
        {
            this.Policy = policy;
        }
    }
}
