using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public abstract class AbstractSqlRepository
    {
        protected FruitracersContext Context { get; private set; }

        public AbstractSqlRepository(FruitracersContext context)
        {
            this.Context = context;
        }
    }
}
