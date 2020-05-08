using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class OwnerOrAdminOnlyAttribute : Attribute, IAuthorizationFilter
    {
        private const string DefaultKey = "userId";

        public string PropertyName { get; set; } = DefaultKey;

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            IUserSession session = context.HttpContext.RequestServices.GetRequiredService<IUserSession>();

            if (session.HasRole(RoleType.Administrator))
            {
                return;
            }

            if (context.RouteData.Values.TryGetValue(this.PropertyName, out object value))
            {
                int userIdParam = int.Parse(value.ToString());
                if (!session.IsLoggedIn || session.UserId != userIdParam)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
