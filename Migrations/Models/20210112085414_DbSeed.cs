using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class DbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "VolumId",
                table: "Poezii",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Volume",
                columns: new[] { "Id", "Denumire" },
                values: new object[] { 1, "Volum 1" });

            migrationBuilder.InsertData(
                table: "Volume",
                columns: new[] { "Id", "Denumire" },
                values: new object[] { 2, "Volum 2" });

            migrationBuilder.InsertData(
                table: "Volume",
                columns: new[] { "Id", "Denumire" },
                values: new object[] { 3, "Volum 3" });

            migrationBuilder.InsertData(
                table: "Poezii",
                columns: new[] { "Id", "Autor", "Strofe", "Titlu", "VolumId" },
                values: new object[,]
                {
                    { 1, "Ion Popescu", 4, "Ursul Pacalit de Vulpe", 1 },
                    { 2, "Mihai Eminovici", 98, "Luceafarul", 1 },
                    { 3, "Mihai Eminovici", 98, "Luceafarul", 2 },
                    { 4, "Autor 4", 4, "Pozie 4", 2 },
                    { 5, "Autor 5", 5, "Poezie 5", 3 },
                    { 6, "Autor 6", 6, "Pozie 6", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poezii_VolumId",
                table: "Poezii",
                column: "VolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poezii_Volume_VolumId",
                table: "Poezii",
                column: "VolumId",
                principalTable: "Volume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poezii_Volume_VolumId",
                table: "Poezii");

            migrationBuilder.DropIndex(
                name: "IX_Poezii_VolumId",
                table: "Poezii");

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Poezii",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Volume",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Volume",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volume",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "VolumId",
                table: "Poezii");

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
    }
}
