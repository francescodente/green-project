using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class PriceModel : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> entity)
        {
            entity.HasKey(e => new { e.Type, e.ItemId });

            entity.Property(e => e.Type)
                .HasConversion(new EnumToStringConverter<CustomerType>())
                .HasMaxLength(10);

            entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(8, 4)");

            entity.Property(e => e.UnitName)
                .HasConversion(new EnumToStringConverter<UnitName>())
                .HasMaxLength(10);

            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.Item)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
