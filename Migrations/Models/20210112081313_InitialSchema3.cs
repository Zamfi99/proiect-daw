using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class InitialSchema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volume_Poezii_PozieModelId",
                table: "Volume");

            migrationBuilder.DropIndex(
                name: "IX_Volume_PozieModelId",
                table: "Volume");

            migrationBuilder.DropColumn(
                name: "PozieModelId",
                table: "Volume");

            migrationBuilder.AddColumn<int>(
                name: "VolumModelId",
                table: "Poezii",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poezii_VolumModelId",
                table: "Poezii",
                column: "VolumModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poezii_Volume_VolumModelId",
                table: "Poezii",
                column: "VolumModelId",
                principalTable: "Volume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poezii_Volume_VolumModelId",
                table: "Poezii");

            migrationBuilder.DropIndex(
                name: "IX_Poezii_VolumModelId",
                table: "Poezii");

            migrationBuilder.DropColumn(
                name: "VolumModelId",
                table: "Poezii");

            migrationBuilder.AddColumn<int>(
                name: "PozieModelId",
                table: "Volume",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volume_PozieModelId",
                table: "Volume",
                column: "PozieModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volume_Poezii_PozieModelId",
                table: "Volume",
                column: "PozieModelId",
                principalTable: "Poezii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
