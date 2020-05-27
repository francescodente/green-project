using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class AvailabilityModel : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> entity)
        {
            entity.HasKey(e => e.Day);
        }
    }
}
