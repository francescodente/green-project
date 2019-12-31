using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitRacers.Backend.DataAccess.Migrations
{
    public partial class RefactorImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "SupplierImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "BackgroundImageId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoImageId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BackgroundImageId",
                table: "Suppliers",
                column: "BackgroundImageId",
                unique: true,
                filter: "[BackgroundImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LogoImageId",
                table: "Suppliers",
                column: "LogoImageId",
                unique: true,
                filter: "[LogoImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_ImageId",
                table: "Products",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Images_BackgroundImageId",
                table: "Suppliers",
                column: "BackgroundImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Images_LogoImageId",
                table: "Suppliers",
                column: "LogoImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ImageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Images_BackgroundImageId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Images_LogoImageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_BackgroundImageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_LogoImageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BackgroundImageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LogoImageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierImages",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierImages", x => new { x.SupplierId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_SupplierImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierImages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierImages_ImageId",
                table: "SupplierImages",
                column: "ImageId");
        }
    }
}
