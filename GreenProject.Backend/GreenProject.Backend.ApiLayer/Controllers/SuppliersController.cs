using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] PaginationFilter pagination)
        {
            return Ok(await this.suppliersService.GetAllSuppliers(pagination));
        }
    }
}