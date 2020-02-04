using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/users/{userId}/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        [HttpPut("person")]
        [OwnerOnly]
        public async Task<IActionResult> AssignPersonRole([FromRoute] int userId, [FromBody] PersonDto person)
        {
            return Ok(await this.rolesService.AssignPersonRole(userId, person));
        }

        [HttpPut("customerbusiness")]
        [OwnerOnly]
        public async Task<IActionResult> AssingCustomerBusinessRole([FromRoute] int userId, [FromBody] CustomerBusinessDto customerBusiness)
        {
            return Ok(await this.rolesService.AssignCustomerBusinessRole(userId, customerBusiness));
        }

        [HttpDelete("person")]
        [OwnerOnly]
        public async Task<IActionResult> RemovePersonRole([FromRoute] int userId)
        {
            await this.rolesService.RemovePersonRole(userId);
            return NoContent();
        }

        [HttpDelete("customerbusiness")]
        [OwnerOnly]
        public async Task<IActionResult> RemoveCustomerBusinessRole([FromRoute] int userId)
        {
            await this.rolesService.RemoveCustomerBusinessRole(userId);
            return NoContent();
        }
    }
}