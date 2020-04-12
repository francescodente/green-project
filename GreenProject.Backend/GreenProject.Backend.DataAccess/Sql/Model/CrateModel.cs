using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CrateModel : IEntityTypeConfiguration<Crate>
    {
        public void Configure(EntityTypeBuilder<Crate> entity)
        {
            entity.HasBaseType<PurchasableItem>();
        }
    }
}
