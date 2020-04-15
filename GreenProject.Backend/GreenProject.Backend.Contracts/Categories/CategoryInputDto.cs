namespace GreenProject.Backend.Core.Services
{
    public class CategoryInputDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}