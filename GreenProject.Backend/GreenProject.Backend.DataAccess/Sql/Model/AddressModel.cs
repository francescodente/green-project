using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class AddressModel : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.HasKey(a => a.AddressId);

            entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

            entity.Property(e => e.Telephone)
                .HasMaxLength(20);

            entity.Property(e => e.HouseNumber)
                .HasMaxLength(8);

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Zone)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ZipCode)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
