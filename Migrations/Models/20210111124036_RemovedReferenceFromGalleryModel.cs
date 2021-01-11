using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class RemovedReferenceFromGalleryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdYacht",
                table: "Gallery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdYacht",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
