using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserSession userSession;

        public AuthenticationController(IAuthenticationService authenticationService, IUserSession userSession)
        {
            this.authenticationService = authenticationService;
            this.userSession = userSession;
        }

        [HttpPost("token")]
        public async Task<IActionResult> RequestToken([FromBody] CredentialsDto credentials)
        {
            return Ok(await this.authenticationService.Authenticate(credentials));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            return Ok(await this.authenticationService.RefreshToken(request));
        }

        [HttpPost("changepsw")]
        [RequireLogin]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeRequestDto request)
        {
            await this.authenticationService.ChangePassword(this.userSession.UserId, request);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegistrationDto registration)
        {
            return Ok(await this.authenticationService.RegisterCustomer(registration));
        }
    }
}