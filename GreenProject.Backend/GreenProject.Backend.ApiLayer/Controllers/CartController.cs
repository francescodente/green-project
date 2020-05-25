using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/customers/{userId}/cart")]
    [ApiController]
    [RequireLogin]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetCart([FromRoute] int userId)
        {
            return Ok(await _cartService.GetCartDetails(userId));
        }

        [HttpGet("size")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetCartSize([FromRoute] int userId)
        {
            return Ok(await _cartService.GetCartSize(userId));
        }

        [HttpPost("details")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> InsertCartItem([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input insertion)
        {
            await _cartService.InsertCartItem(userId, insertion);
            return NoContent();
        }

        [HttpPut("details")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> UpdateCartItem([FromRoute] int userId, [FromBody] QuantifiedProductDto.Input insertion)
        {
            await _cartService.UpdateCartItem(userId, insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int userId, [FromRoute] int productId)
        {
            await _cartService.DeleteCartItem(userId, productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        [OwnerOrAdminOnly]
        [RequireLogin(RoleType.Person)]
        public async Task<IActionResult> ConfirmCart([FromRoute] int userId, [FromBody] DeliveryInfoDto.Input deliveryInfo)
        {
            return Ok(await _cartService.ConfirmCart(userId, deliveryInfo));
        }
    }
}