using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
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
        [OwnerOnly]
        public async Task<IActionResult> GetCart([FromRoute] int userId)
        {
            return Ok(await this.cartService.GetCartDetails(userId));
        }

        [HttpPut]
        [OwnerOnly]
        public async Task<IActionResult> UpdateCartDeliveryInfo([FromRoute] int userId, [FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            return Ok(await this.cartService.UpdateCartDeliveryInfo(userId, deliveryInfo));
        }

        [HttpPost("details")]
        [OwnerOnly]
        public async Task<IActionResult> InsertCartItem([FromRoute] int userId, [FromBody] CartItemInputDto insertion)
        {
            await this.cartService.InsertCartItem(userId, insertion);
            return NoContent();
        }

        [HttpPut("details")]
        [OwnerOnly]
        public async Task<IActionResult> UpdateCartItem([FromRoute] int userId, [FromBody] CartItemInputDto insertion)
        {
            await this.cartService.UpdateCartItem(userId, insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        [OwnerOnly]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int userId, [FromRoute] int productId)
        {
            await this.cartService.DeleteCartItem(userId, productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        [OwnerOnly]
        public async Task<IActionResult> ConfirmCart([FromRoute] int userId)
        {
            return Ok(await this.cartService.ConfirmCart(userId));
        }
    }
}