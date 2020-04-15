using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
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
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter pagination, [FromQuery] PurchasableFilters filters)
        {
            return Ok(await this.productsService.GetProducts(pagination, filters));
        }

        [HttpPost]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> InsertProduct([FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.InsertProduct(product));
        }

        [HttpPut("{productId}")]
        [RequireLogin(RoleType.Administrator)]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductInputDto product)
        {
            return Ok(await this.productsService.UpdateProduct(productId, product));
        }

        [HttpDelete("{productId}")]
        [RequireLogin(RoleType.Administrator)]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            await this.productsService.DeleteProduct(productId);
            return NoContent();
        }
    }
}