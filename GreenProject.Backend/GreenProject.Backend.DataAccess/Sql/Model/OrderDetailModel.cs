using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class OrderDetailModel : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.Property(e => e.Price).HasColumnType("money");

            entity.Property(e => e.Quantity);

            entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(8, 4)");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.Details)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Item)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
