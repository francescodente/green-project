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

        public IUserRepository Users =>
            new SqlUserRepository(this.context);

        public IOrderRepository Orders =>
            new SqlOrderRepository(this.context);

        public IProductRepository Products =>
            new SqlProductRepository(this.context);

        public ITimeSlotRepository TimeSlots =>
            new SqlTimeSlotRepository(this.context);

        public IReadOnlyRepository<Category> Categories =>
            new ReadOnlySqlRepository<Category>(this.context, q => q.Include(c => c.Image));

        public IRepository<Address> Addresses =>
            new SqlRepository<Address>(this.context);

        public IRepository<OrderDetail> OrderDetails =>
            new SqlRepository<OrderDetail>(this.context);

        public IRepository<Person> People =>
            new SqlRepository<Person>(this.context, q => q.Include(p => p.User));

        public IRepository<CustomerBusiness> CustomerBusinesses =>
            new SqlRepository<CustomerBusiness>(this.context, q => q.Include(p => p.User));

        public IRepository<Supplier> Suppliers =>
            new SqlRepository<Supplier>(this.context, q => q.Include(p => p.User).ThenInclude(u => u.Addresses));

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
