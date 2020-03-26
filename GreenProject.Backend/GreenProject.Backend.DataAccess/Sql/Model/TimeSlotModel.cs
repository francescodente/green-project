using System;
using System.Collections.Generic;
using System.Text;
using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class TimeSlotModel : IModelCreator
    {
        public void UpdateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.Property(e => e.FinishTime).HasColumnType("time(0)");

                entity.Property(e => e.StartTime).HasColumnType("time(0)");
            });
        }
    }
}
