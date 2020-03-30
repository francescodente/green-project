using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderModel : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderNumber)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.DeliveryDate).HasColumnType("date");

            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.Property(e => e.OrderState) // TODO: Check if nullable type can be converted
                .HasConversion(new EnumToStringConverter<OrderState>())
                .HasMaxLength(20);

            entity.Property(e => e.Subtotal).HasColumnType("money");

            entity.Property(e => e.Iva).HasColumnType("money");

            entity.Property(e => e.ShippingCost).HasColumnType("money");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
