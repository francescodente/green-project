using System;
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
    [Route(ApiRoutes.BaseRoute + "/support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [HttpPost]
        public async Task<IActionResult> SendSupportEmail([FromBody] SupportRequestDto request)
        {
            await _supportService.SendSupportEmail(request);
            return NoContent();
        }
    }
}