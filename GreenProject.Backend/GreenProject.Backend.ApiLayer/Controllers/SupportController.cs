using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Support;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [HttpPost]
        public async Task<IActionResult> SendSupportEmail([FromBody] SupportRequestDto request)
        {
            await _supportService.SendSupportEmail(request);
            return NoContent();
        }
    }
}