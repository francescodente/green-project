using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Orders.Delivery;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/customers/{userId}/weeklyorder")]
    [ApiController]
    [RequireLogin(RoleType.Person)]
    [OwnerOrAdminOnly]
    public class WeeklyOrdersController : ControllerBase
    {
        private readonly IWeeklyOrdersService weeklyOrdersService;

        public WeeklyOrdersController(IWeeklyOrdersService weeklyOrdersService)
        {
            this.weeklyOrdersService = weeklyOrdersService;
        }

        [HttpPost("subscription")]
        public async Task<IActionResult> Subscribe([FromRoute] int userId, [FromBody] DeliveryInfoDto.Input deliveryInfo)
        {
            return Ok(await this.weeklyOrdersService.Subscribe(userId, deliveryInfo));
        }

        [HttpDelete("subscription")]
        public async Task<IActionResult> Unsubscribe([FromRoute] int userId)
        {
            await this.weeklyOrdersService.Unsubscribe(userId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeeklyOrderDeliveryInfo([FromRoute] int userId, [FromBody] DeliveryInfoDto.Input deliveryInfo)
        {
            await this.weeklyOrdersService.UpdateDeliveryInfo(userId, deliveryInfo);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetWeeklyOrderData([FromRoute] int userId)
        {
            return Ok(await this.weeklyOrdersService.GetWeeklyOrderData(userId));
        }

        [HttpPut("skip")]
        public async Task<IActionResult> SkipWeeks([FromRoute] int userId, [FromQuery] int weeks)
        {
            await this.weeklyOrdersService.SkipWeeks(userId, weeks);
            return NoContent();
        }

        [HttpPost("crates")]
        public async Task<IActionResult> AddCrateToWeeklyOrder([FromRoute] int userId, [FromBody] int crateId)
        {
            await this.weeklyOrdersService.AddCrate(userId, crateId);
            return NoContent();
        }

        [HttpPost("extras")]
        public async Task<IActionResult> AddExtraProductToWeeklyOrder([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input product)
        {
            await this.weeklyOrdersService.AddExtraProduct(userId, product);
            return NoContent();
        }

        [HttpPut("extras")]
        public async Task<IActionResult> UpdateExtraProductInWeeklyOrder([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input product)
        {
            await this.weeklyOrdersService.UpdateExtraProduct(userId, product);
            return NoContent();
        }

        [HttpDelete("details/{orderDetailId}")]
        public async Task<IActionResult> RemoveItemFromWeeklyOrder([FromRoute] int userId, [FromRoute] int orderDetailId)
        {
            await this.weeklyOrdersService.RemoveItem(userId, orderDetailId);
            return NoContent();
        }

        [HttpPost("crates/{orderDetailId}/subproducts")]
        public async Task<IActionResult> AddProductToCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductDto.Input product)
        {
            await this.weeklyOrdersService.AddProductToCrate(userId, orderDetailId, product);
            return NoContent();
        }

        [HttpDelete("crates/{orderDetailId}/subproducts/{productId}")]
        public async Task<IActionResult> RemoveProductFromCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromRoute] int productId)
        {
            await this.weeklyOrdersService.RemoveProductFromCrate(userId, orderDetailId, productId);
            return NoContent();
        }

        [HttpPut("crates/{orderDetailId}/subproducts")]
        public async Task<IActionResult> UpdateProductInCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductDto.Input update)
        {
            await this.weeklyOrdersService.UpdateProductInCrate(userId, orderDetailId, update);
            return NoContent();
        }
    }
}