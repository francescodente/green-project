using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CrateCompatibilityModel : IEntityTypeConfiguration<CrateCompatibility>
    {
        public void Configure(EntityTypeBuilder<CrateCompatibility> entity)
        {
            entity.HasKey(e => new { e.ProductId, e.CrateId });

            entity.HasOne(e => e.Crate)
                .WithMany(d => d.Compatibilities)
                .HasForeignKey(e => e.CrateId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Product)
                .WithMany(d => d.Compatibilities)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
