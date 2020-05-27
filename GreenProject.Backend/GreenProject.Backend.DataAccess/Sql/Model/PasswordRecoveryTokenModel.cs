using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class PasswordRecoveryTokenModel : IEntityTypeConfiguration<PasswordRecoveryToken>
    {
        public void Configure(EntityTypeBuilder<PasswordRecoveryToken> entity)
        {
            entity.HasBaseType<UserToken>();
        }
    }
}
