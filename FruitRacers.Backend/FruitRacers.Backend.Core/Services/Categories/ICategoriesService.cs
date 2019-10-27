using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Categories
{
    public interface ICategoriesService
    {
        Task<CategoryTreeDto> GetAllCategories();
    }
}
