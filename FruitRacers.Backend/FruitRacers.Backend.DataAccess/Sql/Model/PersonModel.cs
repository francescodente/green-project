using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.DataAccess.Sql.Model
{
    public class PersonModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserPeop__1788CC4CFCB3A631");

                entity.ToTable("People");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Cf)
                    .HasColumnName("CF")
                    .HasMaxLength(16);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPeople_Users");
            });
        }
    }
}
