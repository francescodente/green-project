using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderDetailSubProductModel : IEntityTypeConfiguration<OrderDetailSubProduct>
    {
        public void Configure(EntityTypeBuilder<OrderDetailSubProduct> entity)
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId, e.CrateId });

            entity.HasOne(e => e.Product)
                .WithMany(p => p.SubProducts)
                .HasForeignKey(e => e.ProductId);

            entity.HasOne(e => e.OrderDetail)
                .WithMany(d => d.SubProducts)
                .HasForeignKey(e => new { e.OrderId, e.CrateId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
