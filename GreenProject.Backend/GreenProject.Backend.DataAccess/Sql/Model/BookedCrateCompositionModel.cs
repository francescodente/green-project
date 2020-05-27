using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class BookedCrateCompositionModel : IEntityTypeConfiguration<BookedCrateComposition>
    {
        public void Configure(EntityTypeBuilder<BookedCrateComposition> entity)
        {
            entity.HasKey(e => new { e.BookedCrateId, e.ProductId });

            entity.HasOne(e => e.BookedCrate)
                .WithMany(d => d.Compositions)
                .HasForeignKey(e => e.BookedCrateId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Product)
                .WithMany(d => d.Compositions)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
