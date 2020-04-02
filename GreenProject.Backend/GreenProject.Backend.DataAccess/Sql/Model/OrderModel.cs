using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderModel : IEntityTypeConfiguration<Order>
    {
        private const int YEAR_LENGTH = 4;
        private const int DAY_LENGTH = 3;
        private const int ID_LENGTH = 4;

        private static readonly string YEAR_FORMAT = $"FORMAT(YEAR([{nameof(Order.Timestamp)}]), 'D{YEAR_LENGTH}')";
        private static readonly string DAY_FORMAT = $"FORMAT(DATEPART(dayofyear, [{nameof(Order.Timestamp)}]), 'D{DAY_LENGTH}')";
        private static readonly string ID_FORMAT = $"FORMAT([{nameof(Order.OrderId)}] % {Math.Pow(10, ID_LENGTH)}, 'D{ID_LENGTH}')";

        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderNumber)
                .IsRequired()
                .HasColumnType($"nchar({YEAR_LENGTH + DAY_LENGTH + ID_LENGTH})")
                .ValueGeneratedOnAdd()
                .HasComputedColumnSql($"{YEAR_FORMAT} + {DAY_FORMAT} + {ID_FORMAT}");

            entity.Property(e => e.DeliveryDate).HasColumnType("date");

            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.Property(e => e.OrderState)
                .HasConversion(new EnumToStringConverter<OrderState>())
                .HasMaxLength(20);

            entity.Property(e => e.Subtotal).HasColumnType("money");

            entity.Property(e => e.Iva).HasColumnType("money");

            entity.Property(e => e.ShippingCost).HasColumnType("money");

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
