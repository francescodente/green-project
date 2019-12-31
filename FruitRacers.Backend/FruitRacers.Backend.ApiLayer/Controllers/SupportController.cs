using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/support")]
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