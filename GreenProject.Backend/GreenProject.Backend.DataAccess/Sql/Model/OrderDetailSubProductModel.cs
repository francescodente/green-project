using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderDetailSubProductModel : IEntityTypeConfiguration<OrderDetailSubProduct>
    {
        public void Configure(EntityTypeBuilder<OrderDetailSubProduct> entity)
        {
            entity.HasKey(e => new { e.OrderDetailId, e.ProductId });

            entity.HasOne(e => e.Product)
                .WithMany(p => p.SubProducts)
                .HasForeignKey(e => e.ProductId);

            entity.HasOne(e => e.OrderDetail)
                .WithMany(d => d.SubProducts)
                .HasForeignKey(e => e.OrderDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
