using FruitRacers.Backend.Core;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.DataAccess.Sql;
using FruitRacers.Backend.DataAccess.Sql.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess
{
    public class SqlDataSession : IDataSession
    {
        private readonly FruitracersContext context;

        public SqlDataSession(FruitracersContext context)
        {
            this.context = context;
        }

        public IUserRepository Users => new SqlUserRepository(this.context);

        public IOrderRepository Orders => new SqlOrderRepository(this.context);

        public IProductRepository Products => new SqlProductRepository(this.context);

        public ITimeSlotRepository TimeSlots => new SqlTimeSlotRepository(this.context);

        public IReadOnlyRepository<Category> Categories => new ReadOnlySqlRepository<Category>(this.context);

        public IRepository<Address> Addresses => new SqlRepository<Address>(this.context);

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
