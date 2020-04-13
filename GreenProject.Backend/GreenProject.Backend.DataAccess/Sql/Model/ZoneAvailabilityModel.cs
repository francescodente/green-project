using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ZoneAvailabilityModel : IEntityTypeConfiguration<ZoneAvailability>
    {
        public void Configure(EntityTypeBuilder<ZoneAvailability> entity)
        {
            entity.HasKey(e => new { e.Day, e.ZipCode });

            entity.HasOne(e => e.Zone)
                .WithMany(d => d.Availabilities)
                .HasForeignKey(e => e.ZipCode)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Availability)
                .WithMany(d => d.Zones)
                .HasForeignKey(e => e.Day)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
