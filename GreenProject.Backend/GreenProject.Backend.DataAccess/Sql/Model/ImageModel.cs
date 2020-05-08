using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ImageModel : IEntityTypeConfiguration<Image>
    {
        public const int PathSize = 100;

        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity.HasKey(e => e.ImageId);
            
            entity.Property(e => e.Path)
                .IsRequired()
                .HasMaxLength(PathSize);
        }
    }
}
