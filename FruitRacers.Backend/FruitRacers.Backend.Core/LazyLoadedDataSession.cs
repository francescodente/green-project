using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;

namespace FruitRacers.Backend.Core
{
    public class LazyLoadedDataSession : IDataSession
    {
        private readonly IDataSession session;

        private IUserRepository users;
        private IOrderRepository orders;
        private IProductRepository products;
        private ITimeSlotRepository timeSlots;
        private IReadOnlyRepository<Category> categories;
        private IRepository<Address> addresses;
        private IRepository<OrderDetail> orderDetails;
        private IRepository<UserPerson> people;
        private IRepository<UserBusinessCustomer> customerBusinesses;
        private IRepository<UserBusinessSupplier> suppliers;

        public LazyLoadedDataSession(IDataSession session)
        {
            this.session = session;
        }

        public IUserRepository Users => this.users ?? (this.users = this.session.Users);

        public IOrderRepository Orders => this.orders ?? (this.orders = this.session.Orders);

        public IProductRepository Products => this.products ?? (this.products = this.session.Products);

        public ITimeSlotRepository TimeSlots => this.timeSlots ?? (this.timeSlots = this.session.TimeSlots);

        public IReadOnlyRepository<Category> Categories => this.categories ?? (this.categories = this.session.Categories);

        public IRepository<Address> Addresses => this.addresses ?? (this.addresses = this.session.Addresses);

        public IRepository<OrderDetail> OrderDetails => this.orderDetails ?? (this.orderDetails = this.session.OrderDetails);

        public IRepository<UserPerson> People => this.people ?? (this.people = this.session.People);

        public IRepository<UserBusinessCustomer> CustomerBusinesses => this.customerBusinesses ?? (this.customerBusinesses = this.session.CustomerBusinesses);

        public IRepository<UserBusinessSupplier> Suppliers => this.suppliers ?? (this.suppliers = this.session.Suppliers);

        public void Dispose()
        {
            this.session.Dispose();
        }

        public async Task SaveChanges()
        {
            await this.session.SaveChanges();
        }
    }
}
