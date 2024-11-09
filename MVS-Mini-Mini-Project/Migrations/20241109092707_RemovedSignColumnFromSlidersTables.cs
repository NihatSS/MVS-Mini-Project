using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVS_Mini_Mini_Project.Migrations
{
    public partial class RemovedSignColumnFromSlidersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Sliders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
