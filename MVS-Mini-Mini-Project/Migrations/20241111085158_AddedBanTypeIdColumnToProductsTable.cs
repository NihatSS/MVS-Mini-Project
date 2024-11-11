using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVS_Mini_Mini_Project.Migrations
{
    public partial class AddedBanTypesIdColumnToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BanTypesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BanTypesId",
                table: "Products",
                column: "BanTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BanTypes_BanTypesId",
                table: "Products",
                column: "BanTypesId",
                principalTable: "BanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_BanTypes_BanTypesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BanTypesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BanTypesId",
                table: "Products");
        }
    }
}
