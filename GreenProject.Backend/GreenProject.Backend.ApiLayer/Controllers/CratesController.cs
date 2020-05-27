using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/crates")]
    [ApiController]
    public class CratesController : ControllerBase
    {
        private readonly ICratesService _cratesService;

        public CratesController(ICratesService cratesService)
        {
            _cratesService = cratesService;
        }

        [HttpGet]
        [KeepInCacheFor(20)]
        public async Task<IActionResult> GetCrates([FromQuery] PaginationFilter pagination, [FromQuery] PurchasableFilters filters)
        {
            return Ok(await _cratesService.GetCrates(pagination, filters));
        }

        [HttpPost]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> InsertCrate([FromBody] CrateDto.Input crate)
        {
            return Ok(await _cratesService.InsertCrate(crate));
        }

        [HttpPut("{crateId}")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> UpdateCrate([FromRoute] int crateId, [FromBody] CrateDto.Input crate)
        {
            return Ok(await _cratesService.UpdateCrate(crateId, crate));
        }

        [HttpDelete("{crateId}")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> DeleteCrate([FromRoute] int crateId)
        {
            await _cratesService.DeleteCrate(crateId);
            return NoContent();
        }

        [HttpGet("{crateId}/compatibilities")]
        public async Task<IActionResult> GetCrateCompatibilities([FromRoute] int crateId)
        {
            return Ok(await _cratesService.GetCompatibleProducts(crateId));
        }
    }
}
