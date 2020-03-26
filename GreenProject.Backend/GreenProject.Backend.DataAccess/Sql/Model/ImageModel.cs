using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ImageModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
