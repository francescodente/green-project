using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Session;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IRequestSession requestSession;

        public AuthenticationController(IAuthenticationService authenticationService, IRequestSession requestSession)
        {
            this.authenticationService = authenticationService;
            this.requestSession = requestSession;
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
            return Ok(await this.authenticationService.RenewToken(this.requestSession.UserId));
        }

        [HttpGet("logout")]
        [RequireLogin]
        public async Task<IActionResult> Logout()
        {
            await this.authenticationService.Logout(this.requestSession.UserId);
            return NoContent();
        }

        [HttpPost("changepsw")]
        [RequireLogin]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeRequestDto request)
        {
            await this.authenticationService.ChangePassword(this.requestSession.UserId, request);
            return NoContent();
        }
    }
}