using System.Threading.Tasks;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/users")]
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
            return Ok(await this.usersService.GetUserData(this.GetUserId()));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            await this.usersService.DeleteUser(this.GetUserId());
            return NoContent();
        }
    }
}