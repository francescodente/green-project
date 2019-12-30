using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.InsertProduct(product));
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.UpdateProduct(productId, product));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            await this.productsService.DeleteProduct(productId);
            return NoContent();
        }
    }
}