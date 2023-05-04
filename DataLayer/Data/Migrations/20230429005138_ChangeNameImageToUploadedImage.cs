using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameImageToUploadedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Image_ImageId",
                table: "Drink");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.CreateTable(
                name: "UploadedImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uploaded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeneratedImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedImage_GeneratedImage_GeneratedImageId",
                        column: x => x.GeneratedImageId,
                        principalTable: "GeneratedImage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedImage_GeneratedImageId",
                table: "UploadedImage",
                column: "GeneratedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_UploadedImage_ImageId",
                table: "Drink",
                column: "ImageId",
                principalTable: "UploadedImage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_UploadedImage_ImageId",
                table: "Drink");

            migrationBuilder.DropTable(
                name: "UploadedImage");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedImageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uploaded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_GeneratedImage_GeneratedImageId",
                        column: x => x.GeneratedImageId,
                        principalTable: "GeneratedImage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_GeneratedImageId",
                table: "Image",
                column: "GeneratedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Image_ImageId",
                table: "Drink",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }
    }
}
