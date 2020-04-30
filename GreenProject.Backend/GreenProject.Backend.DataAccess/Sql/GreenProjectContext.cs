using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<BookedCrate> BookedCrates { get; set; }
        public DbSet<OrderDetailSubProduct> OrderDetailSubProducts { get; set; }
        public DbSet<BookedCrateComposition> Compositions { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Crate> Crates { get; set; }
        public DbSet<CrateCompatibility> CrateCompatibilities { get; set; }
        public DbSet<CustomerBusiness> CustomerBusinesses { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchasableItem> PurchasableItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneAvailability> ZoneAvailabilities { get; set; }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GreenProjectContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
