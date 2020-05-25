﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [RequireLogin(RoleType.Administrator)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut("users/{userId}/enable")]
        public async Task<IActionResult> SetUserEnabledState([FromRoute] int userId, [FromBody] bool enabled)
        {
            await _adminService.SetUserEnabledState(userId, enabled);
            return NoContent();
        }
    }
}