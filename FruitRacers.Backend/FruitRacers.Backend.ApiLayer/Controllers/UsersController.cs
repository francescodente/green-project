using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
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
        [OwnerOnly]
        public async Task<IActionResult> GetUserData([FromRoute] int userId)
        {
            return Ok(await this.usersService.GetUserData(userId));
        }

        [HttpDelete("{userId}")]
        [OwnerOnly]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            await this.usersService.DeleteUser(userId);
            return NoContent();
        }
    }
}