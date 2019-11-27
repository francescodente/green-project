using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Session;
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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IRequestSession requestSession;

        public CartController(ICartService cartService, IRequestSession requestSession)
        {
            this.cartService = cartService;
            this.requestSession = requestSession;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            return Ok(await this.cartService.GetCartDetailsForUser(this.requestSession.UserId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDeliveryInfo([FromBody] DeliveryInfoDto deliveryInfo)
        {
            await this.cartService.UpdateCartDeliveryInfoForUser(this.requestSession.UserId, deliveryInfo);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCartItem([FromBody] CartInsertionDto insertion)
        {
            await this.cartService.InsertCartItemForUser(this.requestSession.UserId, insertion);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartInsertionDto insertion)
        {
            await this.cartService.UpdateCartItemForUser(this.requestSession.UserId, insertion);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteCartItem([FromServices] int productId)
        {
            await this.cartService.DeleteCartItemForUser(this.requestSession.UserId, productId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ConfirmCart()
        {
            int orderId = await this.cartService.ConfirmCartForUser(this.requestSession.UserId);
            return Ok(new { OrderId = orderId });
        }
    }
}