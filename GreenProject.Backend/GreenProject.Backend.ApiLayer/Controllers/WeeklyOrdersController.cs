using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Contracts.WeeklyOrders;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/customers/{userId}/weeklyorder")]
    [ApiController]
    [RequireLogin(RoleType.Person)]
    [OwnerOrAdminOnly]
    public class WeeklyOrdersController : ControllerBase
    {
        private readonly IWeeklyOrdersService _weeklyOrdersService;

        public WeeklyOrdersController(IWeeklyOrdersService weeklyOrdersService)
        {
            _weeklyOrdersService = weeklyOrdersService;
        }

        [HttpPost("subscription")]
        public async Task<IActionResult> Subscribe([FromRoute] int userId, [FromBody] DeliveryInfoDto.Input deliveryInfo)
        {
            return Ok(await _weeklyOrdersService.Subscribe(userId, deliveryInfo));
        }

        [HttpDelete("subscription")]
        public async Task<IActionResult> Unsubscribe([FromRoute] int userId)
        {
            await _weeklyOrdersService.Unsubscribe(userId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeeklyOrderDeliveryInfo([FromRoute] int userId, [FromBody] DeliveryInfoDto.Input deliveryInfo)
        {
            await _weeklyOrdersService.UpdateDeliveryInfo(userId, deliveryInfo);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetWeeklyOrderData([FromRoute] int userId)
        {
            return Ok(await _weeklyOrdersService.GetWeeklyOrderData(userId));
        }

        [HttpPut("skip")]
        public async Task<IActionResult> SkipWeeks([FromRoute] int userId, [FromQuery] int weeks)
        {
            await _weeklyOrdersService.SkipWeeks(userId, weeks);
            return NoContent();
        }

        [HttpPost("crates")]
        public async Task<IActionResult> AddCrateToWeeklyOrder([FromRoute] int userId, [FromBody] CrateInsertionDto crate)
        {
            return Ok(await _weeklyOrdersService.AddCrate(userId, crate));
        }

        [HttpPost("extras")]
        public async Task<IActionResult> AddExtraProductToWeeklyOrder([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input product)
        {
            return Ok(await _weeklyOrdersService.AddExtraProduct(userId, product));
        }

        [HttpPut("extras")]
        public async Task<IActionResult> UpdateExtraProductInWeeklyOrder([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input product)
        {
            await _weeklyOrdersService.UpdateExtraProduct(userId, product);
            return NoContent();
        }

        [HttpDelete("details/{orderDetailId}")]
        public async Task<IActionResult> RemoveItemFromWeeklyOrder([FromRoute] int userId, [FromRoute] int orderDetailId)
        {
            await _weeklyOrdersService.RemoveItem(userId, orderDetailId);
            return NoContent();
        }

        [HttpPost("crates/{orderDetailId}/subproducts")]
        public async Task<IActionResult> AddProductToCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductDto.Input product)
        {
            await _weeklyOrdersService.AddProductToCrate(userId, orderDetailId, product);
            return NoContent();
        }

        [HttpDelete("crates/{orderDetailId}/subproducts/{productId}")]
        public async Task<IActionResult> RemoveProductFromCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromRoute] int productId)
        {
            await _weeklyOrdersService.RemoveProductFromCrate(userId, orderDetailId, productId);
            return NoContent();
        }

        [HttpPut("crates/{orderDetailId}/subproducts")]
        public async Task<IActionResult> UpdateProductInCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductDto.Input update)
        {
            await _weeklyOrdersService.UpdateProductInCrate(userId, orderDetailId, update);
            return NoContent();
        }
    }
}