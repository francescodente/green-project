using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Categories
{
    public class CategoryTreeDto
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<CategoryTreeDto> Children { get; set; }
    }
}
