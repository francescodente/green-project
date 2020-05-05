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
    [Route(ApiRoutes.BASE_ROUTE + "/crates")]
    [ApiController]
    public class CratesController : ControllerBase
    {
        private readonly ICratesService cratesService;

        public CratesController(ICratesService cratesService)
        {
            this.cratesService = cratesService;
        }

        [HttpGet]
        [KeepInCacheFor(20)]
        public async Task<IActionResult> GetCrates([FromQuery] PaginationFilter pagination, [FromQuery] PurchasableFilters filters)
        {
            return Ok(await this.cratesService.GetCrates(pagination, filters));
        }

        [HttpPost]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> InsertCrate([FromBody] CrateDto.Input crate)
        {
            return Ok(await this.cratesService.InsertCrate(crate));
        }

        [HttpPut("{crateId}")]
        [RequireLogin(RoleType.Administrator)]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> UpdateCrate([FromRoute] int crateId, [FromBody] CrateDto.Input crate)
        {
            return Ok(await this.cratesService.UpdateCrate(crateId, crate));
        }

        [HttpDelete("{crateId}")]
        [RequireLogin(RoleType.Administrator)]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteCrate([FromRoute] int crateId)
        {
            await this.cratesService.DeleteCrate(crateId);
            return NoContent();
        }

        [HttpGet("{crateId}/compatibilities")]
        public async Task<IActionResult> GetCrateCompatibilities([FromRoute] int crateId)
        {
            return Ok(await this.cratesService.GetCompatibleProducts(crateId));
        }
    }
}
