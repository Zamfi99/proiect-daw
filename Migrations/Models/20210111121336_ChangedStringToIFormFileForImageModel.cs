using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class ChangedStringToIFormFileForImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filename",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filename",
                table: "Images",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
