using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ZoneModel : IEntityTypeConfiguration<Zone>
    {
        public const int ZipCodeSize = 5;
        public const int ProvinceSize = 25;
        public const int CitySize = 30;

        public void Configure(EntityTypeBuilder<Zone> entity)
        {
            entity.HasKey(e => e.ZipCode);

            entity.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(ZipCodeSize);

            entity.Property(e => e.Province)
                .IsRequired()
                .HasMaxLength(ProvinceSize);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(CitySize);

            entity.Property(e => e.ShippingSurcharge)
                .HasTypeMoney();
        }
    }
}
