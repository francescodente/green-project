using GreenProject.Backend.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql
{
    public static class CustomTypes
    {
        public static PropertyBuilder<T> HasTypeDate<T>(this PropertyBuilder<T> property)
        {
            return property.HasColumnType("date");
        }

        public static PropertyBuilder<T> HasTypeDateTime<T>(this PropertyBuilder<T> property)
        {
            return property.HasColumnType("datetime");
        }

        public static PropertyBuilder<Money> HasTypeMoney(this PropertyBuilder<Money> property)
        {
            return property
                .HasColumnType("money")
                .HasConversion(m => m.Value, d => new Money(d));
        }

        public static PropertyBuilder<T> HasTypeDecimal<T>(this PropertyBuilder<T> property, int precision, int scale = 0)
        {
            return property.HasColumnType($"decimal({precision}, {scale})");
        }
    }
}
