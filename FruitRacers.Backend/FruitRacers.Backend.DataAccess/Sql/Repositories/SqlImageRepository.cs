using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlImageRepository : SqlRepository<Image>
    {
        public SqlImageRepository(FruitracersContext context)
            : base(context)
        {
        }
    }
}
