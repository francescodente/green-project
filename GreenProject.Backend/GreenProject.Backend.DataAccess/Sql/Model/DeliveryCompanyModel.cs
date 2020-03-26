using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class DeliveryCompanyModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryCompany>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.DeliveryCompany)
                    .HasForeignKey<DeliveryCompany>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
