using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await this.usersService.GetUserData());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            await this.usersService.DeleteUser();
            return NoContent();
        }
    }
}