using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Glass_GlassId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_GlassId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Garnish",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "GlassId",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "Prompt",
                table: "Glass",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Drink",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEX = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garnish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garnish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transparency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transparency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasIce = table.Column<bool>(type: "bit", nullable: false),
                    GlassId = table.Column<int>(type: "int", nullable: false),
                    GarnishId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    TransparencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Style_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Style_Garnish_GarnishId",
                        column: x => x.GarnishId,
                        principalTable: "Garnish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Style_Glass_GlassId",
                        column: x => x.GlassId,
                        principalTable: "Glass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Style_Transparency_TransparencyId",
                        column: x => x.TransparencyId,
                        principalTable: "Transparency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "HEX", "Name", "Prompt" },
                values: new object[,]
                {
                    { 1, "#FF3737", "Röd", "Red" },
                    { 2, "#FF8337", "Orange", "Orange" },
                    { 3, "#C29867", "Brun", "Brown" },
                    { 4, "#FFE272", "Gul", "Yellow" },
                    { 5, "#9DE16F", "Grön", "Green" },
                    { 6, "#36D8B7", "Turkos", "Turquoise" },
                    { 7, "#53AFFF", "Blå", "Blue" },
                    { 8, "#DE6FFF", "Lila", "Purple" },
                    { 9, "#FF74BC", "Rosa", "Pink" },
                    { 10, "#BCCDDE", "Grå", "Grey" },
                    { 11, "#222831", "Svart", "Black" },
                    { 12, "#FFFFFF", "Vit", "White" }
                });

            migrationBuilder.InsertData(
                table: "Transparency",
                columns: new[] { "Id", "Name", "Prompt" },
                values: new object[,]
                {
                    { 1, "Transparent", "water" },
                    { 2, "Semi transparent", "frozen slush" },
                    { 3, "Solid", "milk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_ImageId",
                table: "Drink",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_StyleId",
                table: "Drink",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_ColorId",
                table: "Style",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_GarnishId",
                table: "Style",
                column: "GarnishId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_GlassId",
                table: "Style",
                column: "GlassId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_TransparencyId",
                table: "Style",
                column: "TransparencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Image_ImageId",
                table: "Drink",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Style_StyleId",
                table: "Drink",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Image_ImageId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Style_StyleId",
                table: "Drink");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Garnish");

            migrationBuilder.DropTable(
                name: "Transparency");

            migrationBuilder.DropIndex(
                name: "IX_Drink_ImageId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_StyleId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "Prompt",
                table: "Glass");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Drink");

            migrationBuilder.AddColumn<string>(
                name: "Garnish",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GlassId",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_GlassId",
                table: "Recipe",
                column: "GlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Glass_GlassId",
                table: "Recipe",
                column: "GlassId",
                principalTable: "Glass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
