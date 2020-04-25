using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class RemovePriceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropColumn(
                name: "UnitMultiplier",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Multiplier",
                table: "CrateCompatibilities");

            migrationBuilder.AddColumn<int>(
                name: "CrateMultiplier",
                table: "PurchasableItems",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitMultiplier",
                table: "PurchasableItems",
                type: "decimal(8, 4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitName",
                table: "PurchasableItems",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PurchasableItems",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrateMultiplier",
                table: "PurchasableItems");

            migrationBuilder.DropColumn(
                name: "UnitMultiplier",
                table: "PurchasableItems");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "PurchasableItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PurchasableItems");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitMultiplier",
                table: "OrderDetails",
                type: "decimal(8, 4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitName",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Multiplier",
                table: "CrateCompatibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Type = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitMultiplier = table.Column<decimal>(type: "decimal(8, 4)", nullable: false),
                    UnitName = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ItemId",
                table: "Prices",
                column: "ItemId");
        }
    }
}
