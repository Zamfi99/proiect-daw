using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class UserToBookingString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropIndex("IX_Booking_UserId", "Booking");
            // migrationBuilder.DropForeignKey("FK_Booking_User_UserId", "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Booking",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            
            // migrationBuilder.CreateIndex(
            //     name: "IX_Booking_UserId",
            //     table: "Booking",
            //     column: "UserId");
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_Booking_User_UserId",
            //     table: "Booking",
            //     column: "UserId",
            //     principalTable: "User",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Booking",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId1",
                table: "Booking",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserId1",
                table: "Booking",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
