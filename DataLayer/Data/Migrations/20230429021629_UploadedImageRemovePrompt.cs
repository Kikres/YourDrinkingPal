using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class UploadedImageRemovePrompt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prompt",
                table: "UploadedImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prompt",
                table: "UploadedImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
