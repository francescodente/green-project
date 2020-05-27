using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class AddressModel : IEntityTypeConfiguration<Address>
    {
        public const int StreetSize = 100;
        public const int TelephoneSize = 20;
        public const int HouseNumberSize = 8;
        public const int NameSize = 50;

        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.HasKey(a => a.AddressId);

            entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(StreetSize);

            entity.Property(e => e.Telephone)
                .HasMaxLength(TelephoneSize);

            entity.Property(e => e.HouseNumber)
                .HasMaxLength(HouseNumberSize);

            entity.Property(e => e.Name)
                .HasMaxLength(NameSize);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Zone)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ZipCode)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
