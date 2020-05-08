using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ProductModel : IEntityTypeConfiguration<Product>
    {
        private const int UnitMultiplierPrecision = 8;
        private const int UnitMultiplierScale = 4;

        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasBaseType<PurchasableItem>();

            entity.Property(e => e.UnitMultiplier).HasTypeDecimal(UnitMultiplierPrecision, UnitMultiplierScale);
        }
    }
}
