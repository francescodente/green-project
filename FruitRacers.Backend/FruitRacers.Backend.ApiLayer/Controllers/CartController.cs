using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [RequireLogin(UserRole.Customer)]
    public class CartController : AbstractController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            return Ok(await this.cartService.GetCartDetailsForUser(this.UserId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDeliveryInfo([FromBody] DeliveryInfoDto deliveryInfo)
        {
            await this.cartService.UpdateCartDeliveryInfoForUser(this.UserId, deliveryInfo);
            return NoContent();
        }

        [HttpPost("details")]
        public async Task<IActionResult> InsertCartItem([FromBody] CartInsertionDto insertion)
        {
            await this.cartService.InsertCartItemForUser(this.UserId, insertion);
            return NoContent();
        }

        [HttpPut("details")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartInsertionDto insertion)
        {
            await this.cartService.UpdateCartItemForUser(this.UserId, insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        public async Task<IActionResult> DeleteCartItem([FromServices] int productId)
        {
            await this.cartService.DeleteCartItemForUser(this.UserId, productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmCart()
        {
            int orderId = await this.cartService.ConfirmCartForUser(this.UserId);
            return Ok(new { OrderId = orderId });
        }
    }
}