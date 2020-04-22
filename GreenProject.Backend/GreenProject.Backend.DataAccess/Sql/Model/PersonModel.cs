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
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date");

            entity.HasOne(d => d.User)
                .WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
