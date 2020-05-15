using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class UserModel : IEntityTypeConfiguration<User>
    {
        public const int EmailSize = 60;
        public const int PasswordSize = 256;
        public const int SaltSize = 256;

        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(EmailSize);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(PasswordSize);

            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(SaltSize);

            entity.HasOne(e => e.DefaultAddress)
                .WithOne()
                .HasForeignKey<User>(e => e.DefaultAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
