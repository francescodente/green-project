using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.DataAccess.Sql.Model;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GreenProject.Backend.DataAccess.Sql
{
    public partial class GreenProjectContext : DbContext, IDataSession
    {
        public GreenProjectContext()
        {
        }

        public GreenProjectContext(DbContextOptions<GreenProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerBusiness> CustomerBusinesses { get; set; }
        public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderSection> OrderSections { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<TimeSlotOverride> TimeSlotOverrides { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ReflectionUtils.InstancesOfSubtypes<IModelCreator>(typeof(GreenProjectContext).Assembly)
                .ForEach(m => m.UpdateModel(modelBuilder));

            base.OnModelCreating(modelBuilder);
        }
    }
}
