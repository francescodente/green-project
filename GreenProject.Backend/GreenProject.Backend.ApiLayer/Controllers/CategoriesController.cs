using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryTree()
        {
            return Ok(await this.categoriesService.GetCategoryTree());
        }
    }
}