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
    [Route(ApiRoutes.BASE_ROUTE + "/customers/{userId}/cart")]
    [ApiController]
    [RequireLogin(RoleType.CustomerBusiness, RoleType.Person)]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetCart([FromRoute] int userId)
        {
            return Ok(await this.cartService.GetCartDetails(userId));
        }

        [HttpPost("details")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> InsertCartItem([FromRoute] int userId, [FromBody] QuantifiedProductInputDto insertion)
        {
            await this.cartService.InsertCartItem(userId, insertion);
            return NoContent();
        }

        [HttpPut("details")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> UpdateCartItem([FromRoute] int userId, [FromBody] QuantifiedProductInputDto insertion)
        {
            await this.cartService.UpdateCartItem(userId, insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int userId, [FromRoute] int productId)
        {
            await this.cartService.DeleteCartItem(userId, productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> ConfirmCart([FromRoute] int userId, [FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            return Ok(await this.cartService.ConfirmCart(userId, deliveryInfo));
        }
    }
}