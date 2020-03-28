﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE)]
    [ApiController]
    [RequireLogin(RoleType.Administrator)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPut("users/{userId}/enable")]
        public async Task<IActionResult> SetUserEnabledState([FromRoute] int userId, [FromBody] bool enabled)
        {
            await this.adminService.SetUserEnabledState(userId, enabled);
            return NoContent();
        }

        [HttpPut("products/{productId}/enable")]
        public async Task<IActionResult> SetProductEnabledState([FromRoute] int productId, [FromBody] bool enabled)
        {
            await this.adminService.SetProductEnabledState(productId, enabled);
            return NoContent();
        }
    }
}