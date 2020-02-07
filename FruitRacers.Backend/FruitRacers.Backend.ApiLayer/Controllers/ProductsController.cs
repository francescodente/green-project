using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/suppliers/{userId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromRoute] int userId, [FromQuery] PaginationFilter pagination, [FromQuery] ProductsFilters filters)
        {
            return Ok(await this.productsService.GetProducts(userId, pagination, filters));
        }

        [HttpPost]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly]
        public async Task<IActionResult> InsertProduct([FromRoute] int userId, [FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.InsertProduct(userId, product));
        }

        [HttpPut("{productId}")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly]
        public async Task<IActionResult> UpdateProduct([FromRoute] int userId, [FromRoute] int productId, [FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.UpdateProduct(userId, productId, product));
        }

        [HttpDelete("{productId}")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly]
        public async Task<IActionResult> DeleteProduct([FromRoute] int userId, [FromRoute] int productId)
        {
            await this.productsService.DeleteProduct(userId, productId);
            return NoContent();
        }
    }
}