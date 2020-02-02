using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.ApiLayer.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        [HttpPut("products/{productId}/main")]
        public async Task<IActionResult> AssignProductImage([FromRoute] int productId, IFormFile imageFile)
        {
            await this.imagesService
                .ProductImage(productId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("categories/{categoryId}/main")]
        public async Task<IActionResult> AssignCategoryImage([FromRoute] int categoryId, IFormFile imageFile)
        {
            await this.imagesService
                .CategoryImage(categoryId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("suppliers/{supplierId}/logo")]
        public async Task<IActionResult> AssignSupplierLogo([FromRoute] int supplierId, IFormFile imageFile)
        {
            await this.imagesService
                .SupplierLogo(supplierId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("suppliers/{supplierId}/background")]
        public async Task<IActionResult> AssignSupplierBackgroundImage([FromRoute] int supplierId, IFormFile imageFile)
        {
            await this.imagesService
                .SupplierBackgroundImage(supplierId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpDelete("products/{productId}/main")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] int productId)
        {
            await this.imagesService.ProductImage(productId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("categories/{categoryId}/main")]
        public async Task<IActionResult> DeleteCategoryImage([FromRoute] int categoryId)
        {
            await this.imagesService.CategoryImage(categoryId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("suppliers/{supplierId}/logo")]
        public async Task<IActionResult> DeleteSupplierLogo([FromRoute] int supplierId)
        {
            await this.imagesService.SupplierLogo(supplierId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("suppliers/{supplierId}/background")]
        public async Task<IActionResult> DeleteSupplierBackgroundImage([FromRoute] int supplierId)
        {
            await this.imagesService.SupplierBackgroundImage(supplierId).Then(img => img.Delete());
            return NoContent();
        }
    }
}