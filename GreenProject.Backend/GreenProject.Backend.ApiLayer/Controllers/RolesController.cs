using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/users/{userId}/roles")]
    [RequireLogin]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpPut("person")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> AssignPersonRole([FromRoute] int userId, [FromBody] PersonDto person)
        {
            return Ok(await _rolesService.AssignPersonRole(userId, person));
        }

        [HttpPut("customerbusiness")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> AssingCustomerBusinessRole([FromRoute] int userId, [FromBody] CustomerBusinessDto customerBusiness)
        {
            return Ok(await _rolesService.AssignCustomerBusinessRole(userId, customerBusiness));
        }

        [HttpDelete("person")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> RemovePersonRole([FromRoute] int userId)
        {
            await _rolesService.RemovePersonRole(userId);
            return NoContent();
        }

        [HttpDelete("customerbusiness")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> RemoveCustomerBusinessRole([FromRoute] int userId)
        {
            await _rolesService.RemoveCustomerBusinessRole(userId);
            return NoContent();
        }
    }
}