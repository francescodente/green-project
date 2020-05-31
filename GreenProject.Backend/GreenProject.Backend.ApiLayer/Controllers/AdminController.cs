using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Admin;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [RequireLogin(RoleType.Administrator)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut("users/{userId}/enable")]
        public async Task<IActionResult> SetUserEnabledState([FromRoute] int userId, [FromBody] EnabledStateDto enabledState)
        {
            await _adminService.SetUserEnabledState(userId, enabledState);
            return NoContent();
        }
    }
}