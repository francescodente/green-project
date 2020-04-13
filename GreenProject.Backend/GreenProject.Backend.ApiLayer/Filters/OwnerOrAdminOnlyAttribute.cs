using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class OwnerOrAdminOnlyAttribute : OwnerOnlyAttribute
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            IUserSession session = context.HttpContext.RequestServices.GetRequiredService<IUserSession>();
            if (session.HasRole(RoleType.Administrator))
            {
                return;
            }
            base.OnAuthorization(context);
        }
    }
}
