using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CustomerBusinessModel : IEntityTypeConfiguration<CustomerBusiness>
    {
        public void Configure(EntityTypeBuilder<CustomerBusiness> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasIndex(e => e.VatNumber)
                .IsUnique();

            entity.Property(e => e.BusinessName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LegalForm)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Pec).HasMaxLength(60);

            entity.Property(e => e.Sdi).HasMaxLength(7);

            entity.Property(e => e.VatNumber)
                .IsRequired()
                .HasMaxLength(16);

            entity.HasOne(d => d.User)
                .WithOne(p => p.CustomerBusiness)
                .HasForeignKey<CustomerBusiness>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
