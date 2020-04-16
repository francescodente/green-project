using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/zones")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly IZonesService zonesService;

        public ZonesController(IZonesService zonesService)
        {
            this.zonesService = zonesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupportedZones()
        {
            return Ok(await this.zonesService.GetSupportedZones());
        }

        [HttpGet("{zipCode}/schedule")]
        public async Task<IActionResult> GetNextAvailableSchedule([FromRoute] string zipCode)
        {
            return Ok(await this.zonesService.GetNextAvailableSchedule(zipCode));
        }
    }
}