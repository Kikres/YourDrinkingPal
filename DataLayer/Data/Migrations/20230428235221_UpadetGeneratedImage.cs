using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpadetGeneratedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "GeneratedImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "GeneratedImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedImage_DrinkId",
                table: "GeneratedImage",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedImage_Drink_DrinkId",
                table: "GeneratedImage",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedImage_Drink_DrinkId",
                table: "GeneratedImage");

            migrationBuilder.DropIndex(
                name: "IX_GeneratedImage_DrinkId",
                table: "GeneratedImage");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "GeneratedImage");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "GeneratedImage");
        }
    }
}
