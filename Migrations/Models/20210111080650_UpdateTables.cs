using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Gallery_GalleryModelId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GalleryModelId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GalleryModelId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "GalleryModelImageModel",
                columns: table => new
                {
                    GalleriesId = table.Column<int>(type: "int", nullable: false),
                    IdImagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryModelImageModel", x => new { x.GalleriesId, x.IdImagesId });
                    table.ForeignKey(
                        name: "FK_GalleryModelImageModel_Gallery_GalleriesId",
                        column: x => x.GalleriesId,
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryModelImageModel_Images_IdImagesId",
                        column: x => x.IdImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryModelImageModel_IdImagesId",
                table: "GalleryModelImageModel",
                column: "IdImagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryModelImageModel");

            migrationBuilder.AddColumn<int>(
                name: "GalleryModelId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_GalleryModelId",
                table: "Images",
                column: "GalleryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Gallery_GalleryModelId",
                table: "Images",
                column: "GalleryModelId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
