﻿using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : AbstractController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<IActionResult> GetProductsForSupplier([FromRoute] int supplierId)
        {
            return Ok(await this.productsService.GetProductsForSupplier(supplierId));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductData([FromRoute] int productId)
        {
            return Ok(await this.productsService.GetProductData(productId));
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductInputDto product)
        {
            int productId = await this.productsService.InsertProductForSupplier(this.UserId, product);
            return CreatedAtAction(nameof(GetProductData), new { ProductId = productId });
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromQuery] int productId, [FromBody] ProductInputDto product)
        {
            await this.productsService.UpdateProductForSupplier(this.UserId, productId, product);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            await this.productsService.DeleteProductForSupplier(this.UserId, productId);
            return NoContent();
        }
    }
}