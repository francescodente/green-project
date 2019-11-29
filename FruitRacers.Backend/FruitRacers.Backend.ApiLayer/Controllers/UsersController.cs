using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    public abstract class UsersController<T> : AbstractController
        where T : AccountDto
    {
        private readonly IUsersService<T> usersService;

        public UsersController(IUsersService<T> usersService)
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
            await this.usersService.DeleteUser(this.UserId);
            return NoContent();
        }
    }
}