using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class UpdateOrderNumberFormatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nchar(12)",
                nullable: false,
                computedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + '-' + FORMAT([OrderId] % 100000, 'D5')",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldComputedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nchar(11)",
                nullable: false,
                computedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + FORMAT([OrderId] % 10000, 'D4')",
                oldClrType: typeof(string),
                oldType: "nchar(12)",
                oldComputedColumnSql: "FORMAT(YEAR([Timestamp]), 'D4') + FORMAT(DATEPART(dayofyear, [Timestamp]), 'D3') + '-' + FORMAT([OrderId] % 100000, 'D5')");
        }
    }
}
