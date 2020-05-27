using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class UserTokenModel : IEntityTypeConfiguration<UserToken>
    {
        public const int TokenSize = 50;

        public void Configure(EntityTypeBuilder<UserToken> entity)
        {
            entity.HasKey(e => e.Token);

            entity.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(TokenSize);

            entity.Property(e => e.CreationDate)
                .HasTypeDateTime();

            entity.Property(e => e.Expiration)
                .HasTypeDateTime();

            entity.HasOne(d => d.User)
                .WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
