using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class OrderModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.OrderState).HasColumnType("int");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Orders_Addresses");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_Orders_TimeSlots");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });
        }
    }
}
