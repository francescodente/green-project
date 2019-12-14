﻿using System.Threading.Tasks;
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
            return Ok(await this.cartService.GetCartDetailsForUser(this.GetUserId()));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDeliveryInfo([FromBody] DeliveryInfoInputDto deliveryInfo)
        {
            await this.cartService.UpdateCartDeliveryInfoForUser(this.GetUserId(), deliveryInfo);
            return NoContent();
        }

        [HttpPost("details")]
        public async Task<IActionResult> InsertCartItem([FromBody] CartItemInputDto insertion)
        {
            await this.cartService.InsertCartItemForUser(this.GetUserId(), insertion);
            return NoContent();
        }

        [HttpPut("details")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItemInputDto insertion)
        {
            await this.cartService.UpdateCartItemForUser(this.GetUserId(), insertion);
            return NoContent();
        }

        [HttpDelete("details/{productId}")]
        public async Task<IActionResult> DeleteCartItem([FromServices] int productId)
        {
            await this.cartService.DeleteCartItemForUser(this.GetUserId(), productId);
            return NoContent();
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmCart()
        {
            int orderId = await this.cartService.ConfirmCartForUser(this.GetUserId());
            return Ok(new { OrderId = orderId });
        }
    }
}