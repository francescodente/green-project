using FruitRacers.Backend.Core;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.DataAccess.Sql;
using FruitRacers.Backend.DataAccess.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.DataAccess.Sql
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

        public IReadOnlyRepository<Category> Categories => new ReadOnlySqlRepository<Category>(this.context, q => q.Include(c => c.Image));

        public IRepository<Address> Addresses => new SqlRepository<Address>(this.context);

        public IRepository<OrderDetail> OrderDetails => new SqlRepository<OrderDetail>(this.context);

        public IRepository<UserPerson> People => new SqlRepository<UserPerson>(this.context, q => q.Include(p => p.User));

        public IRepository<UserBusinessCustomer> CustomerBusinesses => new SqlRepository<UserBusinessCustomer>(this.context);

        public IRepository<UserBusinessSupplier> Suppliers => new SqlRepository<UserBusinessSupplier>(this.context);

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
