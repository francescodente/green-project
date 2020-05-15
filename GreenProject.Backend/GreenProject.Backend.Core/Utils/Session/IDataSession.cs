using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Session
{
    public interface IDataSession : IDisposable
    {
        DbSet<Address> Addresses { get; }
        DbSet<Availability> Availabilities { get; }
        DbSet<BookedCrate> BookedCrates { get; }
        DbSet<OrderDetailSubProduct> OrderDetailSubProducts { get; }
        DbSet<BookedCrateComposition> Compositions { get; }
        DbSet<CartItem> CartItems { get; }
        DbSet<Category> Categories { get; }
        DbSet<Crate> Crates { get; }
        DbSet<CrateCompatibility> CrateCompatibilities { get; }
        DbSet<CustomerBusiness> CustomerBusinesses { get; }
        DbSet<DeliveryMan> DeliveryMen { get; }
        DbSet<Image> Images { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderDetail> OrderDetails { get; }
        DbSet<Person> People { get; }
        DbSet<Product> Products { get; }
        DbSet<PurchasableItem> PurchasableItems { get; }
        DbSet<UserToken> UserTokens { get; }
        DbSet<RefreshToken> RefreshTokens { get; }
        DbSet<PasswordRecoveryToken> PasswordRecoveryTokens { get; }
        DbSet<ConfirmationToken> ConfirmationTokens { get; }
        DbSet<User> Users { get; }
        DbSet<Zone> Zones { get; }
        DbSet<ZoneAvailability> ZoneAvailabilities { get; }

        Task SaveChangesAsync();
    }
}
