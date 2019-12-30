using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/cart")]
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
        public async Task<IActionResult> GetCart()
        {
            return Ok(await this.cartService.GetCartDetails());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDeliveryInfo([FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            return Ok(await this.cartService.UpdateCartDeliveryInfo(deliveryInfo));
        }

        [HttpPost("details")]
        public async Task<IActionResult> InsertCartItem([FromBody] CartItemInputDto insertion)
        {
            await this.cartService.InsertCartItem(insertion);
            return NoContent();
        }

        [HttpPut("details")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItemInputDto insertion)
        {
            await this.cartService.UpdateCartItem(insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int productId)
        {
            await this.cartService.DeleteCartItem(productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmCart()
        {
            return Ok(await this.cartService.ConfirmCart());
        }
    }
}