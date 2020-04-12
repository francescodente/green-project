using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
