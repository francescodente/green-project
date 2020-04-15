using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CategoryModel : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Description)
                .HasMaxLength(100);

            entity.HasOne(d => d.Image)
                .WithOne(p => p.Category)
                .HasForeignKey<Category>(d => d.ImageId);

            entity.HasOne(d => d.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .HasForeignKey(d => d.ParentCategoryId);
        }
    }
}
