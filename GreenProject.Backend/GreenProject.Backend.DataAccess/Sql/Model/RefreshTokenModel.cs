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
        public const int AccessTokenIdSize = 50;

        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.HasBaseType<UserToken>();

            entity.Property(e => e.AccessTokenId)
                .IsRequired()
                .HasMaxLength(AccessTokenIdSize);
        }
    }
}
