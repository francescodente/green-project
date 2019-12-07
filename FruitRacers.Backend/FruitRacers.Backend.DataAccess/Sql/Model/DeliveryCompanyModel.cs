using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class DeliveryCompanyModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryCompany>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeli__1788CC4C840C10FF");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.DeliveryCompany)
                    .HasForeignKey<DeliveryCompany>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeliveryCompanies_Users");
            });
        }
    }
}
