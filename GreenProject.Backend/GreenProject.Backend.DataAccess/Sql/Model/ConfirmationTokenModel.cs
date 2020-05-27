
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class ConfirmationTokenModel : IEntityTypeConfiguration<ConfirmationToken>
    {
        public void Configure(EntityTypeBuilder<ConfirmationToken> entity)
        {
            entity.HasBaseType<UserToken>();
        }
    }
}
