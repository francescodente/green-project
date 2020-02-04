﻿using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Session;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Filters
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
