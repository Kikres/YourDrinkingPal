using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDoneFlagToGeneratedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponseAt",
                table: "GeneratedImage",
                newName: "DoneAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "GeneratedImage",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "GeneratedImage");

            migrationBuilder.RenameColumn(
                name: "DoneAt",
                table: "GeneratedImage",
                newName: "ResponseAt");
        }
    }
}
