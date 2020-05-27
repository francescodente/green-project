using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CrateCompatibilityModel : IEntityTypeConfiguration<CrateCompatibility>
    {
        public void Configure(EntityTypeBuilder<CrateCompatibility> entity)
        {
            entity.HasKey(e => new { e.ProductId, e.CrateId });

            entity.HasOne(e => e.Crate)
                .WithMany(d => d.Compatibilities)
                .HasForeignKey(e => e.CrateId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                .WithMany(d => d.Compatibilities)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
