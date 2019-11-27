using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Session;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;
        private readonly IRequestSession requestSession;

        public ProductsController(IProductsService productsService, IRequestSession requestSession)
        {
            this.productsService = productsService;
            this.requestSession = requestSession;
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
        public async Task<IActionResult> InsertProduct([FromBody] ProductWithPricesDto<int> product)
        {
            int productId = await this.productsService.InsertProductForSupplier(this.requestSession.UserId, product);
            return CreatedAtAction(nameof(GetProductData), new { ProductId = productId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductWithPricesDto<int> product)
        {
            await this.productsService.UpdateProductForSupplier(this.requestSession.UserId, product);
            return NoContent();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            await this.productsService.DeleteProductForSupplier(this.requestSession.UserId, productId);
            return NoContent();
        }
    }
}