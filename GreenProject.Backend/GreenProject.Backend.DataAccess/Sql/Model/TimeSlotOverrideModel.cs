using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class TimeSlotOverrideModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeSlotOverride>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.TimeSlotId });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.TimeSlotOverrides)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
