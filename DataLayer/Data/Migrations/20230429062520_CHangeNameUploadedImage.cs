using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class CHangeNameUploadedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_UploadedImage_ImageId",
                table: "Drink");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Drink",
                newName: "UploadedImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Drink_ImageId",
                table: "Drink",
                newName: "IX_Drink_UploadedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_UploadedImage_UploadedImageId",
                table: "Drink",
                column: "UploadedImageId",
                principalTable: "UploadedImage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_UploadedImage_UploadedImageId",
                table: "Drink");

            migrationBuilder.RenameColumn(
                name: "UploadedImageId",
                table: "Drink",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Drink_UploadedImageId",
                table: "Drink",
                newName: "IX_Drink_ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_UploadedImage_ImageId",
                table: "Drink",
                column: "ImageId",
                principalTable: "UploadedImage",
                principalColumn: "Id");
        }
    }
}
