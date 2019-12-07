using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class SupplierImageModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierImage>(entity =>
            {
                entity.HasKey(e => new { e.SupplierId, e.ImageId });

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.SupplierImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierImages_Images");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierImages)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierImages_Suppliers");
            });
        }
    }
}
