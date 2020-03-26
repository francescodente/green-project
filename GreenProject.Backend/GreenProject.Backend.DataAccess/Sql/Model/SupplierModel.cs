using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class SupplierModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.VatNumber)
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

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
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.LogoImage)
                    .WithOne(p => p.LogoOwner)
                    .HasForeignKey<Supplier>(d => d.LogoImageId);

                entity.HasOne(d => d.BackgroundImage)
                    .WithOne(p => p.BackgroundImageOwner)
                    .HasForeignKey<Supplier>(d => d.BackgroundImageId);
            });
        }
    }
}
