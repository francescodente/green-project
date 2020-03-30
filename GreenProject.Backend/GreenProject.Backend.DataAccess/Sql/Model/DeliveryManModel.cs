using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class DeliveryManModel : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.User)
                .WithOne(p => p.DeliveryCompany)
                .HasForeignKey<DeliveryMan>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
