using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDrinkNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Glass_GlassId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Drink",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GlassId",
                table: "Drink",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FlavourId",
                table: "Drink",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink",
                column: "FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Glass_GlassId",
                table: "Drink",
                column: "GlassId",
                principalTable: "Glass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Glass_GlassId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GlassId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlavourId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink",
                column: "FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Glass_GlassId",
                table: "Drink",
                column: "GlassId",
                principalTable: "Glass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
