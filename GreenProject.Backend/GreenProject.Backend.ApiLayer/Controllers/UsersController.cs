using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/users")]
    [ApiController]
    [RequireLogin]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("{userId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetUserData([FromRoute] int userId)
        {
            return Ok(await this.usersService.GetUserData(userId));
        }

        [HttpDelete("{userId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            await this.usersService.DeleteUser(userId);
            return NoContent();
        }
    }
}