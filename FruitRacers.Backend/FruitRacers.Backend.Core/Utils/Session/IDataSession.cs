using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Session
{
    public interface IDataSession : IDisposable
    {
        DbSet<Address> Addresses { get; }
        DbSet<Administrator> Administrators { get; }
        DbSet<Category> Categories { get; }
        DbSet<CustomerBusiness> CustomerBusinesses { get; }
        DbSet<DeliveryCompany> DeliveryCompanies { get; }
        DbSet<Image> Images { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderSection> OrderSections { get; }
        DbSet<OrderDetail> OrderDetails { get; }
        DbSet<Person> People { get; }
        DbSet<Price> Prices { get; }
        DbSet<Product> Products { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<TimeSlot> TimeSlots { get; }
        DbSet<TimeSlotOverride> TimeSlotOverrides { get; }
        DbSet<User> Users { get; }

        Task SaveChangesAsync();
    }
}
