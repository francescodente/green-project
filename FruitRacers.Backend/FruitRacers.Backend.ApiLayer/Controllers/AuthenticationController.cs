﻿using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> RequestToken([FromBody] CredentialsDto credentials)
        {
            return Ok(await this.authenticationService.Authenticate(credentials));
        }

        [HttpGet("renew")]
        [RequireLogin]
        public async Task<IActionResult> RenewToken()
        {
            return Ok(await this.authenticationService.RenewToken());
        }

        [HttpPost("changepsw")]
        [RequireLogin]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeRequestDto request)
        {
            await this.authenticationService.ChangePassword(request);
            return NoContent();
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegistrationDto registration)
        {
            return Ok(await this.authenticationService.RegisterCustomer(registration));
        }

        [HttpPost("register/supplier")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> RegisterSupplier([FromBody] SupplierRegistrationDto registration)
        {
            return Ok(await this.authenticationService.RegisterSupplier(registration));
        }
    }
}