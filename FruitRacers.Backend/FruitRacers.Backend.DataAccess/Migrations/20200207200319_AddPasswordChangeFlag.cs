using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitRacers.Backend.DataAccess.Migrations
{
    public partial class AddPasswordChangeFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsEnabled",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<bool>(
                name: "ShouldChangePassword",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShouldChangePassword",
                table: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnabled",
                table: "Users",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool));
        }
    }
}
