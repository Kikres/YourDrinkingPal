using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneratedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneratedImageId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneratedImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginatingMessageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_GeneratedImageId",
                table: "Image",
                column: "GeneratedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_GeneratedImage_GeneratedImageId",
                table: "Image",
                column: "GeneratedImageId",
                principalTable: "GeneratedImage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_GeneratedImage_GeneratedImageId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "GeneratedImage");

            migrationBuilder.DropIndex(
                name: "IX_Image_GeneratedImageId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "GeneratedImageId",
                table: "Image");
        }
    }
}
