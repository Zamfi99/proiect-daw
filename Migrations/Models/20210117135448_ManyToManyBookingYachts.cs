using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class ManyToManyBookingYachts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Yachts_YachtId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_YachtId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "YachtId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_YachtId",
                table: "Booking",
                column: "YachtId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Yachts_YachtId",
                table: "Booking",
                column: "YachtId",
                principalTable: "Yachts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Yachts_YachtId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_YachtId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "YachtId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_YachtId",
                table: "Booking",
                column: "YachtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Yachts_YachtId",
                table: "Booking",
                column: "YachtId",
                principalTable: "Yachts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
