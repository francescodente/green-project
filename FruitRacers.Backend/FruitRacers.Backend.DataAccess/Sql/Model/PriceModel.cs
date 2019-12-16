using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class PriceModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.ProductId });

                entity.Property(e => e.Type).HasColumnType("nvarchar(10)");

                entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_Products");
            });
        }
    }
}
