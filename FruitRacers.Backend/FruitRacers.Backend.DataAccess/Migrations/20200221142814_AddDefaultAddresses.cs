using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitRacers.Backend.DataAccess.Migrations
{
    public partial class AddDefaultAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultAddressId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultAddressId",
                table: "Users",
                column: "DefaultAddressId",
                unique: true,
                filter: "[DefaultAddressId] IS NOT NULL");

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
                name: "FK_Users_Addresses_DefaultAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DefaultAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DefaultAddressId",
                table: "Users");
        }
    }
}
