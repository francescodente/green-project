using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class PersonModel : IEntityTypeConfiguration<Person>
    {
        public const int FirstNameSize = 50;
        public const int LastNameSize = 50;
        public const int CodeSize = 20;

        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameSize);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(LastNameSize);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(CodeSize);

            entity.Property(e => e.DateOfBirth)
                .HasTypeDate();

            entity.HasOne(d => d.User)
                .WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
