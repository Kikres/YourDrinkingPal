using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIngredientDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Recepie_RecepieId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recepie_RecepieId",
                table: "Instruction");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Recepie_RecepieId",
                table: "Measurement");

            migrationBuilder.DropTable(
                name: "Recepie");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ingridient");

            migrationBuilder.RenameColumn(
                name: "RecepieId",
                table: "Measurement",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurement_RecepieId",
                table: "Measurement",
                newName: "IX_Measurement_RecipeId");

            migrationBuilder.RenameColumn(
                name: "RecepieId",
                table: "Instruction",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_RecepieId",
                table: "Instruction",
                newName: "IX_Instruction_RecipeId");

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garnish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Recipe_RecepieId",
                table: "Drink",
                column: "RecepieId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Recipe_RecipeId",
                table: "Measurement",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Recipe_RecepieId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Recipe_RecipeId",
                table: "Measurement");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Measurement",
                newName: "RecepieId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurement_RecipeId",
                table: "Measurement",
                newName: "IX_Measurement_RecepieId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Instruction",
                newName: "RecepieId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_RecipeId",
                table: "Instruction",
                newName: "IX_Instruction_RecepieId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ingridient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Recepie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepie", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Recepie_RecepieId",
                table: "Drink",
                column: "RecepieId",
                principalTable: "Recepie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recepie_RecepieId",
                table: "Instruction",
                column: "RecepieId",
                principalTable: "Recepie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Recepie_RecepieId",
                table: "Measurement",
                column: "RecepieId",
                principalTable: "Recepie",
                principalColumn: "Id");
        }
    }
}
