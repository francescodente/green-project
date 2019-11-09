using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Dto
{
    public class CategoryTreeDto
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<CategoryTreeDto> Children { get; set; }
    }
}
