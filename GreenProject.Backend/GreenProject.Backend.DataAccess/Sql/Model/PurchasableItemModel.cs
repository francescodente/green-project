using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class PurchasableItemModel : IEntityTypeConfiguration<PurchasableItem>
    {
        public void Configure(EntityTypeBuilder<PurchasableItem> entity)
        {
            entity.HasKey(e => e.ItemId);
            
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IvaPercentage)
                .HasColumnType("decimal(4, 3)");

            entity.Property(e => e.Price)
                .HasTypeMoney();

            entity.HasOne(d => d.Category)
                .WithMany(p => p.PurchasableItems)
                .HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Image)
                .WithOne(p => p.PurchasableItem)
                .HasForeignKey<PurchasableItem>(d => d.ImageId);
        }
    }
}
