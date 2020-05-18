using System;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderModel : IEntityTypeConfiguration<Order>
    {
        public const int NotesSize = 1000;

        private const int YearLength = 4;
        private const int DayLength = 3;
        private const int IdLength = 5;
        private static readonly string YearFormat = $"FORMAT(YEAR([{nameof(Order.Timestamp)}]), 'D{YearLength}')";
        private static readonly string DayFormat = $"FORMAT(DATEPART(dayofyear, [{nameof(Order.Timestamp)}]), 'D{DayLength}')";
        private static readonly string IdFormat = $"FORMAT([{nameof(Order.OrderId)}] % {Math.Pow(10, IdLength)}, 'D{IdLength}')";

        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderNumber)
                .IsRequired()
                .HasColumnType($"nchar({YearLength + DayLength + IdLength})")
                .ValueGeneratedOnAdd()
                .HasComputedColumnSql($"{YearFormat} + {DayFormat} + '-' + {IdFormat}");

            entity.Property(e => e.DeliveryDate).HasTypeDate();

            entity.Property(e => e.Notes).HasMaxLength(NotesSize);

            entity.Property(e => e.Timestamp).HasTypeDateTime();

            entity.Property(e => e.Subtotal).HasTypeMoney();

            entity.Property(e => e.Iva).HasTypeMoney();

            entity.Property(e => e.ShippingCost).HasTypeMoney();

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
