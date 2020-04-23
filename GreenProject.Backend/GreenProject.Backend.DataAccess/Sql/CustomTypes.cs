using GreenProject.Backend.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql
{
    public static class CustomTypes
    {
        public static PropertyBuilder<Money> HasTypeMoney(this PropertyBuilder<Money> property)
        {
            return property
                .HasColumnType("money")
                .HasConversion(m => m.Value, d => new Money(d));
        }
    }
}
