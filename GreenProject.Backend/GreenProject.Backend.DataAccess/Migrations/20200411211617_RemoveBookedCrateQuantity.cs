using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class RemoveBookedCrateQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookedCrates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookedCrates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
