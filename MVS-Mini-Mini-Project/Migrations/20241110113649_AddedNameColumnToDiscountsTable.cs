using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVS_Mini_Mini_Project.Migrations
{
    public partial class AddedNameColumnToDiscountsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discounts");
        }
    }
}
