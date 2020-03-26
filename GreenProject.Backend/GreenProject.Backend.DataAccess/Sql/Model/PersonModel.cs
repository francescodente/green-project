using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class PersonModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Cf)
                    .HasColumnName("CF")
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
