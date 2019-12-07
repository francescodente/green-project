using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class SupplierModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Supplier__1788CC4C3BDD7660");

                entity.HasIndex(e => e.VatNumber)
                    .HasName("UQ__Supplier__654B40BA5D10A839")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LegalForm)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Pec).HasMaxLength(60);

                entity.Property(e => e.Sdi).HasMaxLength(7);

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Supplier)
                    .HasForeignKey<Supplier>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suppliers_Users");
            });
        }
    }
}
