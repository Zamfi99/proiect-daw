using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class AddedRealFilenameForImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealFilename",
                table: "Images",
                type: "varchar(500) CHARACTER SET utf8mb4",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealFilename",
                table: "Images");
        }
    }
}
