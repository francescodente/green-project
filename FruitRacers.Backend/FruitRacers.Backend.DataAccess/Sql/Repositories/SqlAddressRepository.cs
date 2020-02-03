using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlAddressRepository : SqlRepository<Address>
    {
        public SqlAddressRepository(FruitracersContext context)
            : base(context)
        {
        }
    }
}
