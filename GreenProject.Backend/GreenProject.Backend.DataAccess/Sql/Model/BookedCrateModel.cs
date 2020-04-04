using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class BookedCrateModel : IEntityTypeConfiguration<BookedCrate>
    {
        public void Configure(EntityTypeBuilder<BookedCrate> entity)
        {
            entity.HasKey(e => e.BookedCrateId);

            entity.HasOne(e => e.Crate)
                .WithMany(d => d.BookedCrates)
                .HasForeignKey(e => e.CrateId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.User)
                .WithMany(d => d.BookedCrates)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
