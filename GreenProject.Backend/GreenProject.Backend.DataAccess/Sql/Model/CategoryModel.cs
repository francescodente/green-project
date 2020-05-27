using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CategoryModel : IEntityTypeConfiguration<Category>
    {
        public const int NameSize = 30;
        public const int DescriptionSize = 100;

        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(NameSize);

            entity.Property(e => e.Description)
                .HasMaxLength(DescriptionSize);

            entity.HasOne(d => d.Image)
                .WithOne(p => p.Category)
                .HasForeignKey<Category>(d => d.ImageId);

            entity.HasOne(d => d.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .HasForeignKey(d => d.ParentCategoryId);
        }
    }
}
