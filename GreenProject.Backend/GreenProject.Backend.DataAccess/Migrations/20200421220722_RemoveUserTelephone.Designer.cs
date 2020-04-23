﻿// <auto-generated />
using System;
using GreenProject.Backend.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GreenProject.Backend.DataAccess.Migrations
{
    [DbContext(typeof(GreenProjectContext))]
    [Migration("20200421220722_RemoveUserTelephone")]
    partial class RemoveUserTelephone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GreenProject.Backend.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.HasIndex("ZipCode");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Availability", b =>
                {
                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("AvailableSlots")
                        .HasColumnType("int");

                    b.HasKey("Day");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.BookedCrate", b =>
                {
                    b.Property<int>("BookedCrateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookedCrateId");

                    b.HasIndex("CrateId");

                    b.HasIndex("UserId");

                    b.ToTable("BookedCrates");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.BookedCrateComposition", b =>
                {
                    b.Property<int>("BookedCrateId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BookedCrateId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Compositions");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CartItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CrateCompatibility", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CrateId")
                        .HasColumnType("int");

                    b.Property<int?>("Maximum")
                        .HasColumnType("int");

                    b.Property<int>("Multiplier")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CrateId");

                    b.HasIndex("CrateId");

                    b.ToTable("CrateCompatibilities");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CustomerBusiness", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("LegalForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Pec")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Sdi")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("UserId");

                    b.HasIndex("VatNumber")
                        .IsUnique();

                    b.ToTable("CustomerBusinesses");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.DeliveryMan", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("DeliveryMen");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ImageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsSubscription")
                        .HasColumnType("bit");

                    b.Property<decimal>("Iva")
                        .HasColumnType("money");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nchar(11)")
                        .HasComputedColumnSql("FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("money");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("money");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RemainingSlots")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitMultiplier")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<int?>("UnitName")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.OrderDetailSubProduct", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetailSubProducts");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Person", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Price", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitMultiplier")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<int>("UnitName")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("money");

                    b.HasKey("Type", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.PurchasableItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.ToTable("PurchasableItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PurchasableItem");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DefaultAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<bool>("MarketingConsent")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("ShouldChangePassword")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("DefaultAddressId")
                        .IsUnique()
                        .HasFilter("[DefaultAddressId] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Zone", b =>
                {
                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("ZipCode");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.ZoneAvailability", b =>
                {
                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Day", "ZipCode");

                    b.HasIndex("ZipCode");

                    b.ToTable("ZoneAvailabilities");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Crate", b =>
                {
                    b.HasBaseType("GreenProject.Backend.Entities.PurchasableItem");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Crate");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Product", b =>
                {
                    b.HasBaseType("GreenProject.Backend.Entities.PurchasableItem");

                    b.HasDiscriminator().HasValue("Product");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Address", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GreenProject.Backend.Entities.Zone", "Zone")
                        .WithMany("Addresses")
                        .HasForeignKey("ZipCode")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.BookedCrate", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Crate", "Crate")
                        .WithMany("BookedCrates")
                        .HasForeignKey("CrateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithMany("BookedCrates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.BookedCrateComposition", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.BookedCrate", "BookedCrate")
                        .WithMany("Compositions")
                        .HasForeignKey("BookedCrateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Product", "Product")
                        .WithMany("Compositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CartItem", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Category", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Image", "Image")
                        .WithOne("Category")
                        .HasForeignKey("GreenProject.Backend.Entities.Category", "ImageId");

                    b.HasOne("GreenProject.Backend.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CrateCompatibility", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Crate", "Crate")
                        .WithMany("Compatibilities")
                        .HasForeignKey("CrateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Product", "Product")
                        .WithMany("Compatibilities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.CustomerBusiness", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithOne("CustomerBusiness")
                        .HasForeignKey("GreenProject.Backend.Entities.CustomerBusiness", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.DeliveryMan", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithOne("DeliveryCompany")
                        .HasForeignKey("GreenProject.Backend.Entities.DeliveryMan", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Order", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.OrderDetail", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.PurchasableItem", "Item")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.OrderDetailSubProduct", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.OrderDetail", "OrderDetail")
                        .WithMany("SubProducts")
                        .HasForeignKey("OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Product", "Product")
                        .WithMany("SubProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Person", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("GreenProject.Backend.Entities.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.Price", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.PurchasableItem", "Item")
                        .WithMany("Prices")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.PurchasableItem", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Category", "Category")
                        .WithMany("PurchasableItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Image", "Image")
                        .WithOne("PurchasableItem")
                        .HasForeignKey("GreenProject.Backend.Entities.PurchasableItem", "ImageId");
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.User", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Address", "DefaultAddress")
                        .WithOne()
                        .HasForeignKey("GreenProject.Backend.Entities.User", "DefaultAddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GreenProject.Backend.Entities.ZoneAvailability", b =>
                {
                    b.HasOne("GreenProject.Backend.Entities.Availability", "Availability")
                        .WithMany("Zones")
                        .HasForeignKey("Day")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenProject.Backend.Entities.Zone", "Zone")
                        .WithMany("Availabilities")
                        .HasForeignKey("ZipCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}