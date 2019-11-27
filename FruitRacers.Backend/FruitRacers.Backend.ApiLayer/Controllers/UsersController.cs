using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Session;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    public abstract class UsersController<T> : ControllerBase
        where T : AccountDto
    {
        private readonly IUsersService<T> usersService;
        private readonly IRequestSession requestSession;

        public UsersController(IUsersService<T> usersService, IRequestSession requestSession)
        {
            this.usersService = usersService;
            this.requestSession = requestSession;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await this.usersService.GetUserData(this.requestSession.UserId));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationDto<T> registration)
        {
            int id = await this.usersService.Register(registration);
            return Ok(new { UserId = id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] T user)
        {
            await this.usersService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            await this.usersService.DeleteUser(this.requestSession.UserId);
            return NoContent();
        }
    }
}