using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class BookedCrateProductModel : IEntityTypeConfiguration<BookedCrateProduct>
    {
        public void Configure(EntityTypeBuilder<BookedCrateProduct> entity)
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId, e.CrateId });

            entity.HasOne(e => e.Product)
                .WithMany(p => p.BookedCrateProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.OrderDetail)
                .WithMany(d => d.Products)
                .HasForeignKey(e => new { e.OrderId, e.CrateId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
