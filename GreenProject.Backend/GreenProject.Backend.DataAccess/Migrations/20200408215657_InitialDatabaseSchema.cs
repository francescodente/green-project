using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class InitialDatabaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Day = table.Column<int>(nullable: false),
                    AvailableSlots = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Day);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    Province = table.Column<string>(maxLength: 25, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZipCode);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZoneAvailabilities",
                columns: table => new
                {
                    ZipCode = table.Column<string>(nullable: false),
                    Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneAvailabilities", x => new { x.Day, x.ZipCode });
                    table.ForeignKey(
                        name: "FK_ZoneAvailabilities_Availabilities_Day",
                        column: x => x.Day,
                        principalTable: "Availabilities",
                        principalColumn: "Day",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZoneAvailabilities_Zones_ZipCode",
                        column: x => x.ZipCode,
                        principalTable: "Zones",
                        principalColumn: "ZipCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasableItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasableItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_PurchasableItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasableItems_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrateCompatibilities",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CrateId = table.Column<int>(nullable: false),
                    Maximum = table.Column<int>(nullable: false),
                    Multiplier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrateCompatibilities", x => new { x.ProductId, x.CrateId });
                    table.ForeignKey(
                        name: "FK_CrateCompatibilities_PurchasableItems_CrateId",
                        column: x => x.CrateId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrateCompatibilities_PurchasableItems_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false),
                    UnitMultiplier = table.Column<decimal>(type: "decimal(8, 4)", nullable: false),
                    UnitName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => new { x.Type, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Prices_PurchasableItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nchar(11)", nullable: false, computedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')"),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    Iva = table.Column<decimal>(type: "money", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "money", nullable: false),
                    IsSubscription = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    UnitName = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    UnitMultiplier = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_PurchasableItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailSubProducts",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailSubProducts", x => new { x.OrderDetailId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetailSubProducts_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailSubProducts_PurchasableItems_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    Salt = table.Column<string>(maxLength: 256, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: true),
                    MarketingConsent = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsAdministrator = table.Column<bool>(nullable: false),
                    IsSubscribed = table.Column<bool>(nullable: false),
                    ShouldChangePassword = table.Column<bool>(nullable: false),
                    DefaultAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    HouseNumber = table.Column<string>(maxLength: 8, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Zones_ZipCode",
                        column: x => x.ZipCode,
                        principalTable: "Zones",
                        principalColumn: "ZipCode",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BookedCrates",
                columns: table => new
                {
                    BookedCrateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CrateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedCrates", x => x.BookedCrateId);
                    table.ForeignKey(
                        name: "FK_BookedCrates_PurchasableItems_CrateId",
                        column: x => x.CrateId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookedCrates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CartItems_PurchasableItems_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBusinesses",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    VatNumber = table.Column<string>(maxLength: 16, nullable: false),
                    BusinessName = table.Column<string>(maxLength: 100, nullable: false),
                    Sdi = table.Column<string>(maxLength: 7, nullable: true),
                    Pec = table.Column<string>(maxLength: 60, nullable: true),
                    LegalForm = table.Column<string>(maxLength: 10, nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBusinesses", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_CustomerBusinesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMen",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMen", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_DeliveryMen_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_People_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    BookedCrateId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => new { x.BookedCrateId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Compositions_BookedCrates_BookedCrateId",
                        column: x => x.BookedCrateId,
                        principalTable: "BookedCrates",
                        principalColumn: "BookedCrateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compositions_PurchasableItems_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PurchasableItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ZipCode",
                table: "Addresses",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookedCrates_CrateId",
                table: "BookedCrates",
                column: "CrateId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedCrates_UserId",
                table: "BookedCrates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_ProductId",
                table: "Compositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CrateCompatibilities_CrateId",
                table: "CrateCompatibilities",
                column: "CrateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBusinesses_VatNumber",
                table: "CustomerBusinesses",
                column: "VatNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailSubProducts_ProductId",
                table: "OrderDetailSubProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ItemId",
                table: "Prices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasableItems_CategoryId",
                table: "PurchasableItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasableItems_ImageId",
                table: "PurchasableItems",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultAddressId",
                table: "Users",
                column: "DefaultAddressId",
                unique: true,
                filter: "[DefaultAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZoneAvailabilities_ZipCode",
                table: "ZoneAvailabilities",
                column: "ZipCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_DefaultAddressId",
                table: "Users",
                column: "DefaultAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "CrateCompatibilities");

            migrationBuilder.DropTable(
                name: "CustomerBusinesses");

            migrationBuilder.DropTable(
                name: "DeliveryMen");

            migrationBuilder.DropTable(
                name: "OrderDetailSubProducts");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "ZoneAvailabilities");

            migrationBuilder.DropTable(
                name: "BookedCrates");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "PurchasableItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Zones");
        }
    }
}
