using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Categories
{
    public class CategoryTreeDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<CategoryTreeDto> Children { get; set; }
    }
}
