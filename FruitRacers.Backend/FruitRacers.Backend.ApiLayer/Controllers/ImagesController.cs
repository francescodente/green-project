using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Routes;
using FruitRacers.Backend.ApiLayer.Utils;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE)]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        [HttpPut("suppliers/{supplierId}/products/{productId}/images/main")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> AssignProductImage([FromRoute] int supplierId, [FromRoute] int productId, IFormFile imageFile)
        {
            await this.imagesService
                .ProductImage(productId, supplierId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("categories/{categoryId}/images/main")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> AssignCategoryImage([FromRoute] int categoryId, IFormFile imageFile)
        {
            await this.imagesService
                .CategoryImage(categoryId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("suppliers/{supplierId}/images/logo")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> AssignSupplierLogo([FromRoute] int supplierId, IFormFile imageFile)
        {
            await this.imagesService
                .SupplierLogo(supplierId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("suppliers/{supplierId}/images/background")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> AssignSupplierBackgroundImage([FromRoute] int supplierId, IFormFile imageFile)
        {
            await this.imagesService
                .SupplierBackgroundImage(supplierId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpDelete("suppliers/{supplierId}/products/{productId}/images/main")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] int supplierId, [FromRoute] int productId)
        {
            await this.imagesService.ProductImage(productId, supplierId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("categories/{categoryId}/images/main")]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> DeleteCategoryImage([FromRoute] int categoryId)
        {
            await this.imagesService.CategoryImage(categoryId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("suppliers/{supplierId}/images/logo")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> DeleteSupplierLogo([FromRoute] int supplierId)
        {
            await this.imagesService.SupplierLogo(supplierId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("suppliers/{supplierId}/images/background")]
        [RequireLogin(RoleType.Supplier)]
        [OwnerOnly(PropertyName = "supplierId")]
        public async Task<IActionResult> DeleteSupplierBackgroundImage([FromRoute] int supplierId)
        {
            await this.imagesService.SupplierBackgroundImage(supplierId).Then(img => img.Delete());
            return NoContent();
        }
    }
}