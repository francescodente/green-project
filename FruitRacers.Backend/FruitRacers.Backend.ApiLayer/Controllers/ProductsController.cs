using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter pagination, [FromQuery] ProductsFilters filters)
        {
            return Ok(await this.productsService.GetProducts(pagination, filters));
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