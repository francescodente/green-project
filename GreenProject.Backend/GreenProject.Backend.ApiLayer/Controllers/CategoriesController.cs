using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [KeepInCacheFor(60)]
        public async Task<IActionResult> GetCategoryTree()
        {
            return Ok(await _categoriesService.GetCategoryTree());
        }

        [HttpPost]
        [RequireLogin(RoleType.Administrator)]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto.Input category)
        {
            return Ok(await _categoriesService.AddCategory(category));
        }
    }
}