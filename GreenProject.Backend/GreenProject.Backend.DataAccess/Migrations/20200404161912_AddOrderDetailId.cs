using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProject.Backend.DataAccess.Migrations
{
    public partial class AddOrderDetailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedCrateProducts_PurchasableItems_ProductId",
                table: "BookedCrateProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedCrateProducts_OrderDetails_OrderId_CrateId",
                table: "BookedCrateProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedCrateProducts",
                table: "BookedCrateProducts");

            migrationBuilder.DropIndex(
                name: "IX_BookedCrateProducts_OrderId_CrateId",
                table: "BookedCrateProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BookedCrateProducts");

            migrationBuilder.DropColumn(
                name: "CrateId",
                table: "BookedCrateProducts");

            migrationBuilder.RenameTable(
                name: "BookedCrateProducts",
                newName: "OrderDetailSubProducts");

            migrationBuilder.RenameIndex(
                name: "IX_BookedCrateProducts_ProductId",
                table: "OrderDetailSubProducts",
                newName: "IX_OrderDetailSubProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDetailSubProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailSubProducts",
                table: "OrderDetailSubProducts",
                columns: new[] { "OrderDetailId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailSubProducts_OrderDetails_OrderDetailId",
                table: "OrderDetailSubProducts",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailSubProducts_PurchasableItems_ProductId",
                table: "OrderDetailSubProducts",
                column: "ProductId",
                principalTable: "PurchasableItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailSubProducts_OrderDetails_OrderDetailId",
                table: "OrderDetailSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailSubProducts_PurchasableItems_ProductId",
                table: "OrderDetailSubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailSubProducts",
                table: "OrderDetailSubProducts");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDetailSubProducts");

            migrationBuilder.RenameTable(
                name: "OrderDetailSubProducts",
                newName: "BookedCrateProducts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailSubProducts_ProductId",
                table: "BookedCrateProducts",
                newName: "IX_BookedCrateProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "BookedCrateProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrateId",
                table: "BookedCrateProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedCrateProducts",
                table: "BookedCrateProducts",
                columns: new[] { "OrderId", "ProductId", "CrateId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedCrateProducts_OrderId_CrateId",
                table: "BookedCrateProducts",
                columns: new[] { "OrderId", "CrateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedCrateProducts_PurchasableItems_ProductId",
                table: "BookedCrateProducts",
                column: "ProductId",
                principalTable: "PurchasableItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedCrateProducts_OrderDetails_OrderId_CrateId",
                table: "BookedCrateProducts",
                columns: new[] { "OrderId", "CrateId" },
                principalTable: "OrderDetails",
                principalColumns: new[] { "OrderId", "ItemId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
