using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        [HttpPut("person")]
        public async Task<IActionResult> AssignPersonRole([FromBody] PersonDto person)
        {
            return Ok(await this.rolesService.AssignPersonRole(person));
        }

        [HttpPut("customerbusiness")]
        public async Task<IActionResult> AssingCustomerBusinessRole([FromBody] CustomerBusinessDto customerBusiness)
        {
            return Ok(await this.rolesService.AssignCustomerBusinessRole(customerBusiness));
        }

        [HttpDelete("person")]
        public async Task<IActionResult> RemovePersonRole()
        {
            await this.rolesService.RemovePersonRole();
            return NoContent();
        }

        [HttpDelete("customerbusiness")]
        public async Task<IActionResult> RemoveCustomerBusinessRole()
        {
            await this.rolesService.RemoveCustomerBusinessRole();
            return NoContent();
        }
    }
}