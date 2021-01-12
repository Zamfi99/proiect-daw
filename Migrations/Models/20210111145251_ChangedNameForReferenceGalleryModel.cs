using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class ChangedNameForReferenceGalleryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Images_IdImagesId",
                table: "GalleryModelImageModel");

            migrationBuilder.RenameColumn(
                name: "IdImagesId",
                table: "GalleryModelImageModel",
                newName: "ImagesId");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryModelImageModel_IdImagesId",
                table: "GalleryModelImageModel",
                newName: "IX_GalleryModelImageModel_ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImagesId",
                table: "GalleryModelImageModel",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImagesId",
                table: "GalleryModelImageModel");

            migrationBuilder.RenameColumn(
                name: "ImagesId",
                table: "GalleryModelImageModel",
                newName: "IdImagesId");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryModelImageModel_ImagesId",
                table: "GalleryModelImageModel",
                newName: "IX_GalleryModelImageModel_IdImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Images_IdImagesId",
                table: "GalleryModelImageModel",
                column: "IdImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
