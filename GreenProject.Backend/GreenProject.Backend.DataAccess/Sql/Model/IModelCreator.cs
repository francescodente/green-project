using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public interface IModelCreator
    {
        void UpdateModel(ModelBuilder modelBuilder);
    }
}
