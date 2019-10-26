using System;
using FruitRacers.Backend.Core.Entities;
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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<TimeSlotOverride> TimeSlotOverrides { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAdministrator> UserAdministrators { get; set; }
        public virtual DbSet<UserBusiness> UserBusinesses { get; set; }
        public virtual DbSet<UserBusinessCustomer> UserBusinessCustomers { get; set; }
        public virtual DbSet<UserBusinessSupplier> UserBusinessSuppliers { get; set; }
        public virtual DbSet<UserDeliveryCompany> UserDeliveryCompanies { get; set; }
        public virtual DbSet<UserPerson> UserPeoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Users");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Categories_Images");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Images_Products");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Images_Suppliers");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.HasKey(e => e.UnitName)
                    .HasName("PK__Measurem__B5EE667996DCF8DD");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.OrderStateId).HasColumnName("OrderStateID");

                entity.Property(e => e.TimeSlotId).HasColumnName("TimeSlotID");

                entity.Property(e => e.Timestamp).IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Orders_Addresses");

                entity.HasOne(d => d.OrderState)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStates");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_Orders_TimeSlots");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.UnitName).HasMaxLength(5);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");

                entity.HasOne(d => d.UnitNameNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UnitName)
                    .HasConstraintName("FK_OrderDetails_MeasurementUnits");
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.Property(e => e.OrderStateId).HasColumnName("OrderStateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.ProductId });

                entity.Property(e => e.Type).HasMaxLength(1);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_Products");

                entity.HasOne(d => d.UnitNameNavigation)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.UnitName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_MeasurementUnits");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsLegal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategories_Categories");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategories_Products");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.Property(e => e.TimeSlotId).HasColumnName("TimeSlotID");

                entity.Property(e => e.FinishTime).HasColumnType("time(0)");

                entity.Property(e => e.StartTime).HasColumnType("time(0)");
            });

            modelBuilder.Entity<TimeSlotOverride>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.TimeSlotId });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeSlotId).HasColumnName("TimeSlotID");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.TimeSlotOverrides)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSlotOverrides_TimeSlots");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534702DBB3F")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            modelBuilder.Entity<UserAdministrator>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAdmi__1788CCACA3472DB3");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserAdministrator)
                    .HasForeignKey<UserAdministrator>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAdministrators_Users");
            });

            modelBuilder.Entity<UserBusiness>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserBusi__1788CCACB60C6174");

                entity.HasIndex(e => e.VatNumber)
                    .HasName("UQ__UserBusi__654B40BAC05CF796")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LegalForm)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Pec).HasMaxLength(60);

                entity.Property(e => e.Sdi).HasMaxLength(7);

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserBusiness)
                    .HasForeignKey<UserBusiness>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBusinesses_Users");
            });

            modelBuilder.Entity<UserBusinessCustomer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserBusi__1788CCACA9980FBD");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserBusinessCustomer)
                    .HasForeignKey<UserBusinessCustomer>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBusinessCustomers_UserBusinesses");
            });

            modelBuilder.Entity<UserBusinessSupplier>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserBusi__1788CCAC8F29F09E");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<UserDeliveryCompany>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeli__1788CCACAFD4F0A7");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDeliveryCompany)
                    .HasForeignKey<UserDeliveryCompany>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeliveryCompanies_Users");
            });

            modelBuilder.Entity<UserPerson>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserPeop__1788CCAC572D31FB");

                entity.ToTable("UserPeople");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Cf)
                    .HasColumnName("CF")
                    .HasMaxLength(16);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserPerson)
                    .HasForeignKey<UserPerson>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPeople_Users");
            });
        }
    }
}
