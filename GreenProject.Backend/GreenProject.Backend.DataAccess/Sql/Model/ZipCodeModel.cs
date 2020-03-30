using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ZipCodeModel : IEntityTypeConfiguration<ZipCode>
    {
        public void Configure(EntityTypeBuilder<ZipCode> entity)
        {
            entity.HasKey(e => e.Code);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.Province)
                .IsRequired()
                .HasMaxLength(25);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
