using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/customers/{userId}/weeklyorder")]
    [ApiController]
    [RequireLogin(RoleType.Person, RoleType.CustomerBusiness)]
    public class WeeklyOrdersController : ControllerBase
    {
        private readonly IWeeklyOrdersService weeklyOrdersService;

        public WeeklyOrdersController(IWeeklyOrdersService weeklyOrdersService)
        {
            this.weeklyOrdersService = weeklyOrdersService;
        }

        [HttpPost("subscription")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> Subscribe([FromRoute] int userId, [FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            return Ok(await this.weeklyOrdersService.Subscribe(userId, deliveryInfo));
        }

        [HttpDelete("subscription")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> Unsubscribe([FromRoute] int userId)
        {
            await this.weeklyOrdersService.Unsubscribe(userId);
            return NoContent();
        }

        [HttpGet]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetWeeklyOrderData([FromRoute] int userId)
        {
            return Ok(await this.weeklyOrdersService.GetWeeklyOrderData(userId));
        }

        [HttpPost("crates")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> AddCrateToWeeklyOrder([FromRoute] int userId, [FromBody] int crateId)
        {
            await this.weeklyOrdersService.AddCrate(userId, crateId);
            return NoContent();
        }

        [HttpPost("extras")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> AddExtraProductToWeeklyOrder([FromRoute] int userId, [FromBody] QuantifiedProductInputDto product)
        {
            await this.weeklyOrdersService.AddExtraProduct(userId, product);
            return NoContent();
        }

        [HttpDelete("details/{orderDetailId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> RemoveItemFromWeeklyOrder([FromRoute] int userId, [FromRoute] int orderDetailId)
        {
            await this.weeklyOrdersService.RemoveItem(userId, orderDetailId);
            return NoContent();
        }

        [HttpPost("crates/{orderDetailId}/subproducts")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> AddProductToCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductInputDto product)
        {
            await this.weeklyOrdersService.AddProductToCrate(userId, orderDetailId, product);
            return NoContent();
        }

        [HttpDelete("crates/{orderDetailId}/subproducts/{productId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> ProductProductFromCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromRoute] int productId)
        {
            await this.weeklyOrdersService.RemoveProductFromCrate(userId, orderDetailId, productId);
            return NoContent();
        }

        [HttpPut("crates/{orderDetailId}/subproducts/{productId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> UpdateProductInCrate([FromRoute] int userId, [FromRoute] int orderDetailId, [FromBody] QuantifiedProductInputDto update)
        {
            await this.weeklyOrdersService.UpdateProductInCrate(userId, orderDetailId, update);
            return NoContent();
        }
    }
}