﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Support;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService supportService;

        public SupportController(ISupportService supportService)
        {
            this.supportService = supportService;
        }

        [HttpPost]
        public async Task<IActionResult> SendSupportEmail([FromBody] SupportRequestDto request)
        {
            await this.supportService.SendSupportEmail(request);
            return NoContent();
        }
    }
}