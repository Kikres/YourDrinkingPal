using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFromUriToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uri",
                table: "UploadedImage",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "OriginalUri",
                table: "GeneratedImage",
                newName: "OriginalUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "UploadedImage",
                newName: "Uri");

            migrationBuilder.RenameColumn(
                name: "OriginalUrl",
                table: "GeneratedImage",
                newName: "OriginalUri");
        }
    }
}
