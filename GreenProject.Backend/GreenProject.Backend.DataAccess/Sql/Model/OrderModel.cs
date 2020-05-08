using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderModel : IEntityTypeConfiguration<Order>
    {
        private const int YearLength = 4;
        private const int DayLength = 3;
        private const int IdLength = 4;

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
                .HasComputedColumnSql($"{YearFormat} + {DayFormat} + {IdFormat}");

            entity.Property(e => e.DeliveryDate).HasColumnType("date");

            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.Property(e => e.Timestamp).HasColumnType("datetime");

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
