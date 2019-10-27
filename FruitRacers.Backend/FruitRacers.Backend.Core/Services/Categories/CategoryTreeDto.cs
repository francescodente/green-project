using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Categories
{
    public class CategoryTreeDto
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<CategoryTreeDto> Children { get; set; }
    }
}
