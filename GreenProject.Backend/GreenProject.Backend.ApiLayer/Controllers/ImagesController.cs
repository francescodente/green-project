using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.ApiLayer.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [RequireLogin(RoleType.Administrator)]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        [HttpPut("items/{itemId}/images/main")]
        public async Task<IActionResult> AssignItemImage([FromRoute] int itemId, IFormFile imageFile)
        {
            await this.imagesService
                .PurchasableImage(itemId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpPut("categories/{categoryId}/images/main")]
        public async Task<IActionResult> AssignCategoryImage([FromRoute] int categoryId, IFormFile imageFile)
        {
            await this.imagesService
                .CategoryImage(categoryId)
                .Then(img => imageFile.CopyToAsync(img));
            return NoContent();
        }

        [HttpDelete("items/{itemId}/images/main")]
        public async Task<IActionResult> DeleteItemImage([FromRoute] int itemId)
        {
            await this.imagesService.PurchasableImage(itemId).Then(img => img.Delete());
            return NoContent();
        }

        [HttpDelete("categories/{categoryId}/images/main")]
        public async Task<IActionResult> DeleteCategoryImage([FromRoute] int categoryId)
        {
            await this.imagesService.CategoryImage(categoryId).Then(img => img.Delete());
            return NoContent();
        }
    }
}