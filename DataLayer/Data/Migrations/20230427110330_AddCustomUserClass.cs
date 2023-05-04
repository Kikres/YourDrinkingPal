using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Drink",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2c3488bd-6338-40f9-85d0-9e08462c9376", 0, "5644c923140b", "ApplicationUser", "Henrik.johansson@sogeti.com", false, false, false, null, "RootUser", "HENRIK.JOHANSSON@SOGETI.COM", "ROOTUSER", "AN6Kz0IfIzNdho+g+EESPt8IPNukKgPzk6GsEIl78JFayKiB2g9lzxOL4lNi6xgbOw==", null, false, "0180a8d6-cb12-4c23-8638-a47117e05a9d", false, "RootUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_CreatorId",
                table: "Drink",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_AspNetUsers_CreatorId",
                table: "Drink",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_AspNetUsers_CreatorId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_CreatorId",
                table: "Drink");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c3488bd-6338-40f9-85d0-9e08462c9376");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
