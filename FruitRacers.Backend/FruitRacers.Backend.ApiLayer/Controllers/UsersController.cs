using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    public abstract class UsersController<TRole> : AbstractController
        where TRole : RoleDto
    {
        private readonly IUsersService<TRole> usersService;

        public UsersController(IUsersService<TRole> usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await this.usersService.GetUserData(this.UserId));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationDto<TRole> registration)
        {
            int id = await this.usersService.Register(registration);
            return Ok(new { UserId = id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] AccountInputDto<TRole> account)
        {
            await this.usersService.UpdateUser(this.UserId, account);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            await this.usersService.DeleteUser(this.UserId);
            return NoContent();
        }
    }
}