using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [KeepInCacheFor(20)]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter pagination, [FromQuery] PurchasableFilters filters)
        {
            return Ok(await _productsService.GetProducts(pagination, filters));
        }

        [HttpPost]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDto.Insertion product)
        {
            return Ok(await _productsService.InsertProduct(product));
        }

        [HttpPut("{productId}")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductDto.Update product)
        {
            return Ok(await _productsService.UpdateProduct(productId, product));
        }

        [HttpDelete("{productId}")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            await _productsService.DeleteProduct(productId);
            return NoContent();
        }

        [HttpGet("{productId}/compatibilities")]
        public async Task<IActionResult> GetProductCompatibilities([FromRoute] int productId)
        {
            return Ok(await _productsService.GetCompatibleCrates(productId));
        }
    }
}