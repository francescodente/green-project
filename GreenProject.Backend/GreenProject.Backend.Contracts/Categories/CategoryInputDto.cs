namespace GreenProject.Backend.Core.Services
{
    public class CategoryInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}