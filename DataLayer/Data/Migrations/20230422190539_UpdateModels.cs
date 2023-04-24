using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
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
                name: "FK_Drink_Recipe_RecepieId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Unit_UnitId",
                table: "Measurement");

            migrationBuilder.DropTable(
                name: "DrinkTool");

            migrationBuilder.DropIndex(
                name: "IX_Drink_GlassId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "GlassId",
                table: "Drink");

            migrationBuilder.RenameColumn(
                name: "RecepieId",
                table: "Drink",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Drink_RecepieId",
                table: "Drink",
                newName: "IX_Drink_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "GlassId",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Measurement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FlavourId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeTool",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTool", x => new { x.EquipmentId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_RecipeTool_Recipe_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTool_Tool_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Tool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_GlassId",
                table: "Recipe",
                column: "GlassId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTool_RecipesId",
                table: "RecipeTool",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink",
                column: "FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Recipe_RecipeId",
                table: "Drink",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Unit_UnitId",
                table: "Measurement",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Glass_GlassId",
                table: "Recipe",
                column: "GlassId",
                principalTable: "Glass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Flavour_FlavourId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Recipe_RecipeId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Unit_UnitId",
                table: "Measurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Glass_GlassId",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeTool");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_GlassId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "GlassId",
                table: "Recipe");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Drink",
                newName: "RecepieId");

            migrationBuilder.RenameIndex(
                name: "IX_Drink_RecipeId",
                table: "Drink",
                newName: "IX_Drink_RecepieId");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Measurement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
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

            migrationBuilder.AddColumn<int>(
                name: "GlassId",
                table: "Drink",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DrinkTool",
                columns: table => new
                {
                    DrinksId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkTool", x => new { x.DrinksId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_DrinkTool_Drink_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkTool_Tool_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Tool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_GlassId",
                table: "Drink",
                column: "GlassId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkTool_EquipmentId",
                table: "DrinkTool",
                column: "EquipmentId");

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
                name: "FK_Drink_Recipe_RecepieId",
                table: "Drink",
                column: "RecepieId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Tag_TagId",
                table: "Drink",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Unit_UnitId",
                table: "Measurement",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }
    }
}
