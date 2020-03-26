using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CategoryModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.Category)
                    .HasForeignKey<Category>(d => d.ImageId);

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.ChildCategories)
                    .HasForeignKey(d => d.ParentCategoryId);
            });
        }
    }
}
