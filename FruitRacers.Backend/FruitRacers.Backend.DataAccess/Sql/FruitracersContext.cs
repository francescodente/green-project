using System;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.DataAccess.Sql.Model;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FruitRacers.Backend.DataAccess.Sql
{
    public partial class FruitracersContext : DbContext
    {
        public FruitracersContext()
        {
        }

        public FruitracersContext(DbContextOptions<FruitracersContext> options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ReflectionUtils.InstancesOfSubtypes<IModelCreator>(typeof(FruitracersContext).Assembly)
                .ForEach(m => m.UpdateModel(modelBuilder));
        }
    }
}
