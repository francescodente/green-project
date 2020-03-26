using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderSectionModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderSection>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.SupplierId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(p => p.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ReceivedOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
