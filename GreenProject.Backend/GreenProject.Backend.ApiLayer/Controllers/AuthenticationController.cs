using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserSession _userSession;

        public AuthenticationController(IAuthenticationService authenticationService, IUserSession userSession)
        {
            _authenticationService = authenticationService;
            _userSession = userSession;
        }

        [HttpPost("token")]
        public async Task<IActionResult> RequestToken([FromBody] CredentialsDto credentials)
        {
            return Ok(await _authenticationService.Authenticate(credentials));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            return Ok(await _authenticationService.RefreshToken(request));
        }

        [HttpPost("changepsw")]
        [RequireLogin]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeRequestDto request)
        {
            await _authenticationService.ChangePassword(_userSession.UserId, request);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegistrationDto registration)
        {
            return Ok(await _authenticationService.RegisterCustomer(registration));
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAccount([FromBody] AccountConfirmationDto confirmation)
        {
            await _authenticationService.ConfirmAccount(confirmation);
            return NoContent();
        }

        [HttpPost("reactivate")]
        public async Task<IActionResult> ReactivateConfirmation([FromBody] ReactivateConfirmationDto request)
        {
            await _authenticationService.ReactivateConfirmation(request);
            return NoContent();
        }

        [HttpPost("passwordrecovery")]
        public async Task<IActionResult> SendPasswordRecovery([FromBody] PasswordRecoveryRequestDto request)
        {
            await _authenticationService.SendPasswordRecovery(request);
            return NoContent();
        }

        [HttpPost("passwordrecovery/accept")]
        public async Task<IActionResult> AcceptPasswordRecovery([FromBody] PasswordRecoveryChangeDto request)
        {
            await _authenticationService.AcceptPasswordRecovery(request);
            return NoContent();
        }
    }
}