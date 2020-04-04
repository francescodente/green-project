using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class AutoOrderNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nchar(11)",
                nullable: false,
                computedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldComputedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')");
        }
    }
}
