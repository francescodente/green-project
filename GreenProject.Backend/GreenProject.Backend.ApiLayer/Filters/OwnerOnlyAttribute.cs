using GreenProject.Backend.Core.Utils.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class OwnerOnlyAttribute : Attribute, IAuthorizationFilter
    {
        private const string DEFAULT_KEY = "userId";

        public string PropertyName { get; set; } = DEFAULT_KEY;

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.RouteData.Values.ContainsKey(this.PropertyName))
            {
                int userIdParam = int.Parse(context.RouteData.Values[this.PropertyName].ToString());
                IUserSession session = context.HttpContext.RequestServices.GetRequiredService<IUserSession>();
                if (session.UserId != userIdParam)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
