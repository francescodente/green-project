using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
