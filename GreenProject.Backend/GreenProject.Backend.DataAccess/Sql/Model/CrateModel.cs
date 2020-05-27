using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CrateModel : IEntityTypeConfiguration<Crate>
    {
        public void Configure(EntityTypeBuilder<Crate> entity)
        {
            entity.HasBaseType<PurchasableItem>();
        }
    }
}
