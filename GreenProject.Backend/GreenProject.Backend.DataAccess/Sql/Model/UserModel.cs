using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class UserModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.HasOne(e => e.DefaultAddress)
                    .WithOne()
                    .HasForeignKey<User>(e => e.DefaultAddressId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
