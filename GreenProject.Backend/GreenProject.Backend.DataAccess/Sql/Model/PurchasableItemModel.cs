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
        public const int DescriptionSize = 1000;
        public const int NameSize = 100;
        private const int IvaPercentagePrecision = 4;
        private const int IvaPercentageScale = 3;

        public void Configure(EntityTypeBuilder<PurchasableItem> entity)
        {
            entity.HasKey(e => e.ItemId);
            
            entity.Property(e => e.Description).HasMaxLength(DescriptionSize);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(NameSize);

            entity.Property(e => e.IvaPercentage)
                .HasTypeDecimal(IvaPercentagePrecision, IvaPercentageScale);

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
