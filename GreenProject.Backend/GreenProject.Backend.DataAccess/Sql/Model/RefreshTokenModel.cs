using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class RefreshTokenModel : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.HasKey(e => e.Token);

            entity.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.AccessTokenId)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime");

            entity.Property(e => e.Expiration)
                .HasColumnType("datetime");

            entity.HasOne(d => d.User)
                .WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
