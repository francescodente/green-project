using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class CustomerBusinessModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBusiness>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Customer__1788CC4C1BCAC353");

                entity.HasIndex(e => e.VatNumber)
                    .HasName("UQ__Customer__654B40BAF156E0B2")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LegalForm)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Pec).HasMaxLength(60);

                entity.Property(e => e.Sdi).HasMaxLength(7);

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CustomerBusiness)
                    .HasForeignKey<CustomerBusiness>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerBusinesses_Users");
            });
        }
    }
}
