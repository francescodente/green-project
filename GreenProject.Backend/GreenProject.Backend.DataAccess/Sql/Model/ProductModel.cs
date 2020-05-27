using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ProductModel : IEntityTypeConfiguration<Product>
    {
        public const int UnitMultiplierPrecision = 8;
        public const int UnitMultiplierScale = 4;

        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasBaseType<PurchasableItem>();

            entity.Property(e => e.UnitMultiplier).HasTypeDecimal(UnitMultiplierPrecision, UnitMultiplierScale);
        }
    }
}
