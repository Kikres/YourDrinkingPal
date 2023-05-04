using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_UploadedImage_UploadedImageId",
                table: "Drink");

            migrationBuilder.AlterColumn<int>(
                name: "UploadedImageId",
                table: "Drink",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "UploadedImageId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_UploadedImage_UploadedImageId",
                table: "Drink",
                column: "UploadedImageId",
                principalTable: "UploadedImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
