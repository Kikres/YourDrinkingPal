using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipsBetweenClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Drink_DrinkId",
                table: "Tool");

            migrationBuilder.DropIndex(
                name: "IX_Tool_DrinkId",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Tool");

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
                name: "IX_DrinkTool_EquipmentId",
                table: "DrinkTool",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkTool");

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Tool",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tool_DrinkId",
                table: "Tool",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Drink_DrinkId",
                table: "Tool",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "Id");
        }
    }
}
