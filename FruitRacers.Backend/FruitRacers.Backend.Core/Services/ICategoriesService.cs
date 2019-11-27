using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICategoriesService
    {
        Task<CategoryTreeDto> GetCategoryTree();
    }
}
