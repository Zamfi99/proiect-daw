using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Yacht.Migrations.Models
{
    public partial class ChangedNameForReferenceGalleryAndImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Gallery_GalleriesId",
                table: "GalleryModelImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImagesId",
                table: "GalleryModelImageModel");

            migrationBuilder.RenameColumn(
                name: "ImagesId",
                table: "GalleryModelImageModel",
                newName: "ImageModelsId");

            migrationBuilder.RenameColumn(
                name: "GalleriesId",
                table: "GalleryModelImageModel",
                newName: "GalleryModelsId");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryModelImageModel_ImagesId",
                table: "GalleryModelImageModel",
                newName: "IX_GalleryModelImageModel_ImageModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Gallery_GalleryModelsId",
                table: "GalleryModelImageModel",
                column: "GalleryModelsId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImageModelsId",
                table: "GalleryModelImageModel",
                column: "ImageModelsId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Gallery_GalleryModelsId",
                table: "GalleryModelImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImageModelsId",
                table: "GalleryModelImageModel");

            migrationBuilder.RenameColumn(
                name: "ImageModelsId",
                table: "GalleryModelImageModel",
                newName: "ImagesId");

            migrationBuilder.RenameColumn(
                name: "GalleryModelsId",
                table: "GalleryModelImageModel",
                newName: "GalleriesId");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryModelImageModel_ImageModelsId",
                table: "GalleryModelImageModel",
                newName: "IX_GalleryModelImageModel_ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Gallery_GalleriesId",
                table: "GalleryModelImageModel",
                column: "GalleriesId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryModelImageModel_Images_ImagesId",
                table: "GalleryModelImageModel",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
