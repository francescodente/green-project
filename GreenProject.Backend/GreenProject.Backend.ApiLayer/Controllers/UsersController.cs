using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/users")]
    [ApiController]
    [RequireLogin]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{userId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetUserData([FromRoute] int userId)
        {
            return Ok(await _usersService.GetUserData(userId));
        }

        [HttpDelete("{userId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            await _usersService.DeleteUser(userId);
            return NoContent();
        }
    }
}