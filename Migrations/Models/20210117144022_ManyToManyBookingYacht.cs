using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class ManyToManyBookingYacht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Yachts_YachtId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_YachtId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "fk_yacht_booking_id",
                table: "Yachts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yachts_fk_yacht_booking_id",
                table: "Yachts",
                column: "fk_yacht_booking_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Yachts_Booking_fk_yacht_booking_id",
                table: "Yachts",
                column: "fk_yacht_booking_id",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yachts_Booking_fk_yacht_booking_id",
                table: "Yachts");

            migrationBuilder.DropIndex(
                name: "IX_Yachts_fk_yacht_booking_id",
                table: "Yachts");

            migrationBuilder.DropColumn(
                name: "fk_yacht_booking_id",
                table: "Yachts");

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
    }
}
