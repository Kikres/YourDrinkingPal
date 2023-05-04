using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourDrinkingPal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Flavour",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Syrlig" },
                    { 2, "Bitter" },
                    { 3, "Fräsch" },
                    { 4, "Torr" },
                    { 5, "Fruktig" },
                    { 6, "Söt" },
                    { 7, "Stark" },
                    { 8, "Örtig" }
                });

            migrationBuilder.InsertData(
                table: "Garnish",
                columns: new[] { "Id", "Name", "Prompt" },
                values: new object[,]
                {
                    { 1, "Citrontwist", "Lemon peel twist" },
                    { 2, "Apelsintwist", "Orange peel twist" },
                    { 3, "Citronskiva", "Lemon slice" },
                    { 4, "Limeklyfta", "Lime Slice" },
                    { 5, "Selleristjälk", "cellery" },
                    { 6, "Apelsinklyfta", "orange slice" },
                    { 8, "Grön oliv", "Green olive" },
                    { 9, "Färska bär", "Fresh berries" },
                    { 10, "Ananasblad", "Pinapple leaf" },
                    { 11, "Färska hallon", "Fresh raspberry" },
                    { 12, "Ananasskiva", "Pinaple slice" },
                    { 13, "Citronklyfta", "Lemon slice" },
                    { 14, "Limeskiva", "lime slice" },
                    { 15, "Färskt hallon", "Fresh raspberry" },
                    { 16, "Jordgubbe", "Strawberry" },
                    { 17, "Limetwist", "Lime peel twist" },
                    { 18, "Cocktailbär", "Cocktail berry" },
                    { 19, "Grapefruktskal", "Grapefriut peel" },
                    { 20, "Myntakvist", "Mint stalk" },
                    { 21, "Apelsinskiva", "Orange Slice" },
                    { 22, "Basilikakvist", "Basil stalk" },
                    { 23, "Apelsinskal", "Orange peel" },
                    { 24, "Maraschinokörsbär", "Maraschino cherry" },
                    { 25, "Grapefruktskiva", "Grapefruit slice" },
                    { 26, "Äppelskiva", "Apple slice" },
                    { 28, "Persikoskiva", "Peech slice" },
                    { 29, "Grapefrukttwist", "Grapefruit peel twist" },
                    { 30, "Jordgubbsskiva", "Strawberry slice" },
                    { 31, "Citron- eller limeklyfta", "Lemon and Lime peel" },
                    { 32, "Citronskal", "Lemon peel" },
                    { 33, "Bränd apelsintwist", "Orange peel twist" },
                    { 34, "Myntabukett", "Mint buke" },
                    { 35, "Selleri", "Cellery" },
                    { 36, "kanelstång", "cinnamon stick" },
                    { 40, "Syltlök", "Syltlök" },
                    { 42, "Bananskiva", "banana slice" },
                    { 43, "Apelsin- eller citrontwist", "Orange and lemon peel twist" },
                    { 44, "Myntablad", "Mintleaf" },
                    { 46, "Citrontwist eller oliv", "lemon peel twist and olive" },
                    { 47, "Passionsfrukt", "passion-fruit" },
                    { 48, "3 kaffebönor", "coffebeans" }
                });

            migrationBuilder.InsertData(
                table: "Glass",
                columns: new[] { "Id", "Name", "Prompt" },
                values: new object[,]
                {
                    { 1, "Champagne", "Champagne" },
                    { 2, "Old Fashioned", "Old Fashioned" },
                    { 3, "Highball", "Highball" },
                    { 4, "Cocktail", "Cocktail" },
                    { 5, "Collins", "Collins" },
                    { 6, "Dubbel Old Fashioned", "Double Old Fashioned" },
                    { 7, "Vinglas", "Wine Glass" },
                    { 8, "Toddy", "Toddy" },
                    { 9, "Gin & Tonic", "Gin & Tonic" },
                    { 10, "Julep cup", "Julep Cup" },
                    { 11, "Martini", "Martini" },
                    { 12, "Hurricane", "Hurricane" },
                    { 13, "Kopparbägare", "Copper Mug" },
                    { 14, "Margarita", "Margarita" }
                });

            migrationBuilder.InsertData(
                table: "Ingridient",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "bourbon" },
                    { 2, "champagne" },
                    { 3, "färskpressad citronjuice" },
                    { 4, "extra söt sockerlag (2:1)" },
                    { 5, "akvavit" },
                    { 6, "Campari" },
                    { 7, "iste" },
                    { 8, "lemonad" },
                    { 9, "alkoholfri rom" },
                    { 10, "lime" },
                    { 11, "sockerlag (1:1)" },
                    { 12, "myntablad" },
                    { 13, "soda" },
                    { 14, "tomatjuice" },
                    { 15, "Worcestershiresås" },
                    { 16, "svartpeppar" },
                    { 17, "chilisås" },
                    { 18, "kall ljus lager" },
                    { 19, "färskpressad apelsinjuice" },
                    { 20, "gin" },
                    { 21, "fino eller manzanilla sherry" },
                    { 22, "mezcal" },
                    { 23, "Cointreau" },
                    { 24, "färskpressad limejuice" },
                    { 25, "torr vermouth" },
                    { 26, "Old Tom gin" },
                    { 27, "orange bitters" },
                    { 28, "amontillado sherry" },
                    { 29, "apelsinskivor" },
                    { 30, "grön Chartreuse" },
                    { 31, "falernum" },
                    { 32, "färskpressad ananasjuice" },
                    { 33, "Lillet Blanc" },
                    { 34, "Suze" },
                    { 35, "vodka" },
                    { 36, "hallonlikör" },
                    { 37, "svartvinbärslikör" },
                    { 38, "färska hallon" },
                    { 39, "blanco tequila" },
                    { 40, "Drambuie" },
                    { 41, "iskall soda" },
                    { 42, "amaretto" },
                    { 43, "sloe gin" },
                    { 44, "olivspad" },
                    { 45, "limeklyfta" },
                    { 46, "ljus rom" },
                    { 47, "gold rom" },
                    { 48, "bananlikör" },
                    { 49, "Galliano" },
                    { 50, "kokoslikör" },
                    { 51, "kokosmjölk" },
                    { 52, "citrongräs" },
                    { 53, "tunna skivor ingefära" },
                    { 54, "thaichili" },
                    { 55, "kaffir limeblad" },
                    { 56, "absint" },
                    { 57, "aguardiente eller ljus kubansk rom" },
                    { 58, "honungssyrup (1:1)" },
                    { 59, "blended skotsk whisky" },
                    { 60, "röd vermouth" },
                    { 61, "Angostura bitters" },
                    { 62, "färskpressad grapefruktjuice" },
                    { 63, "whiskey" },
                    { 64, "Chambord" },
                    { 65, "genever" },
                    { 66, "orgeat" },
                    { 67, "mörk rom" },
                    { 68, "tawny portvin" },
                    { 69, "kokosrom" },
                    { 70, "tranbärsjuice" },
                    { 71, "agavesirap" },
                    { 72, "färska jordgubbar" },
                    { 73, "salt" },
                    { 74, "hibiskussockerlag" },
                    { 75, "rye whiskey" },
                    { 76, "grenadin" },
                    { 77, "Sprite eller ginger ale" },
                    { 78, "brandy" },
                    { 79, "mjölk (3 %)" },
                    { 80, "vispgrädde" },
                    { 81, "ginger ale" },
                    { 82, "irländsk whiskey" },
                    { 83, "tonic" },
                    { 84, "cachaça" },
                    { 85, "bianco vermouth" },
                    { 86, "mörk jamaicansk rom" },
                    { 87, "75-procentig demerararom" },
                    { 88, "fassionolasyrup " },
                    { 89, "iskall mexikansk lager" },
                    { 90, "Bénédictine" },
                    { 91, "saltlag (1:1)" },
                    { 92, "apelsinblomsvatten" },
                    { 93, "añejo tequila" },
                    { 94, "smaksatt sockerlag" },
                    { 95, "vispgrädde eller vaniljglass" },
                    { 96, "kryddsmör" },
                    { 97, "kokhett vatten" },
                    { 98, "Advocaat" },
                    { 99, "vitt vin" },
                    { 100, "billigt rödvin" },
                    { 101, "färska basilikablad" },
                    { 102, "Tabasco" },
                    { 103, "färskmalen svartpeppar" },
                    { 104, "torrt vitt vin" },
                    { 105, "maraschinolikör" },
                    { 106, "gul Chartreuse" },
                    { 107, "Jägermeister" },
                    { 108, "passionsfruktsockerlag" },
                    { 109, "socker" },
                    { 110, "Cynar" },
                    { 111, "färskpressad röd grapefruktjuice" },
                    { 112, "dry curaçao" },
                    { 113, "applejack eller calvados" },
                    { 114, "Jack Daniel's Tennessee whiskey" },
                    { 115, "Sprite eller 7 Up" },
                    { 116, "calvados" },
                    { 117, "orange curaçao" },
                    { 118, "allspice dram" },
                    { 119, "cognac" },
                    { 120, "anisette" },
                    { 121, "rörsocker" },
                    { 122, "kanelstänger" },
                    { 123, "nejlikor" },
                    { 124, "stjärnanis" },
                    { 125, "kardemummakapslar" },
                    { 126, "riven ingefära" },
                    { 127, "riven muskot" },
                    { 128, "apelsin" },
                    { 129, "rosévin" },
                    { 130, "äpple" },
                    { 131, "vaniljstång" },
                    { 132, "Navy Strength gin" },
                    { 133, "Aperol" },
                    { 134, "Angostura orange bitters" },
                    { 135, "mangopuré" },
                    { 136, "oloroso sherry" },
                    { 137, "ägg" },
                    { 138, "citronklyftor" },
                    { 139, "persikor" },
                    { 140, "fino sherry" },
                    { 141, "lagrad rom" },
                    { 142, "röd vermouth, vit vermouth eller torr vermouth" },
                    { 143, "jordgubbsinfunderad Campari" },
                    { 144, "färskpressad juice" },
                    { 145, "Seagram's 7 Crown whiskey" },
                    { 146, "7 Up" },
                    { 147, "råsockerlag (1:1)" },
                    { 148, "bourbon, rye eller brandy" },
                    { 149, "aprikoslikör" },
                    { 150, "spiced rum" },
                    { 151, "mörk navy strength rom" },
                    { 152, "björnbärslikör" },
                    { 153, "gurkskivor " },
                    { 154, "hallonsockerlag" },
                    { 155, "ginger beer" },
                    { 156, "molebitters " },
                    { 157, "mörk rhum agricole" },
                    { 158, "Dubonnet " },
                    { 159, "crème de cacao " },
                    { 160, "orange curaçao eller Cointreau" },
                    { 161, "crème de menthe" },
                    { 162, "äggvita eller aquafaba" },
                    { 163, "pisco" },
                    { 164, "Luxardo Bitter Bianco " },
                    { 165, "skotsk whisky" },
                    { 166, "jamaicansk rom" },
                    { 167, "St-Germain" },
                    { 168, "Fernet " },
                    { 169, "Cola " },
                    { 170, "fino, manzanilla eller amontillado sherry" },
                    { 171, "mynta" },
                    { 172, "Lustau East India sherry" },
                    { 173, "jordgubbssockerlag " },
                    { 174, "brandy eller cognac" },
                    { 175, "Ruby Port portvin " },
                    { 176, "ananassyrup " },
                    { 177, "Amer Picon " },
                    { 178, "extra söt råsockerlag (2:1)" },
                    { 179, "flaska (75 cl) torrt vitt vin" },
                    { 180, "citron " },
                    { 181, "ginger ale eller soda" },
                    { 182, "flaska (75 cl) cava" },
                    { 183, "persika " },
                    { 184, "hallon" },
                    { 185, "flaska (75 cl) rosévin" },
                    { 186, "flaska (75 cl) torrt rött vin" },
                    { 187, "jordgubbar" },
                    { 188, "torrt rött vin" },
                    { 189, "peach bitters" },
                    { 190, "Fever Tree Elderflower tonic" },
                    { 191, "Scrappy's Lavender bitters" },
                    { 192, "Prosecco" },
                    { 193, "apelsininfunderad Aperol" },
                    { 194, "passionsfruktslikör" },
                    { 195, "passionsfrukt" },
                    { 196, "vaniljvodka" },
                    { 197, "Butterscotch Schnapps" },
                    { 198, "hallonpuré" },
                    { 199, "blackstrap-rom" },
                    { 200, "Wray & Nephew White Overproof rom" },
                    { 201, "Ting" },
                    { 202, "blue curaçao" },
                    { 203, "gold rom t ex Gosling's Gold Seal" },
                    { 204, "ljus kubansk rom" },
                    { 205, "whiskey, bourbon, mörk rom eller cognac" },
                    { 206, "honung" },
                    { 207, "varmt vatten" },
                    { 208, "apricot brandy" },
                    { 209, "reposado tequila" },
                    { 210, "Highland malt skotsk whisky" },
                    { 211, "stora ägg" },
                    { 212, "crème de noyaux" },
                    { 213, "Punt e Mes vermouth" },
                    { 214, "amaro" },
                    { 215, "Peychaud's bitters" },
                    { 216, "färskpressad äppeljuice" },
                    { 217, "rabarbersockerlag (1:1)" },
                    { 218, "passionsfruktpuré" },
                    { 219, "Midori" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Variant av en klassiker" },
                    { 2, "Alkoholfri drink" },
                    { 3, "Öldrink" },
                    { 4, "Klassisk cocktail" },
                    { 5, "Modern klassiker" },
                    { 6, "Fräsch törstsläckare" },
                    { 7, "Fräsch sommardrink" },
                    { 8, "Svalkande törstsläckare" },
                    { 9, "Kultklassiker" },
                    { 10, "Modern cocktail" },
                    { 11, "Läskande törstsläckare" },
                    { 12, "Svalkande sommardrink" },
                    { 13, "Tikifavorit" },
                    { 14, "Ölcocktail" },
                    { 15, "Dessertcocktail" },
                    { 16, "Bitter sippare" },
                    { 17, "Klassisk vintervärmare" },
                    { 18, "Sommarfavorit" },
                    { 19, "Söt sippare" },
                    { 20, "Klassisk juldryck" },
                    { 21, "Sommardrink" },
                    { 22, "Enkel grogg" },
                    { 23, "Klassisk cocktal" },
                    { 24, "Modern Tikidrink" },
                    { 25, "Tikiklassiker" },
                    { 26, "Twist på en klassiker" },
                    { 27, "Sommarklassiker" },
                    { 28, "Brunchdrink" },
                    { 29, "Populär sour" },
                    { 30, "Karibisk törstsläckare" },
                    { 31, "Tropisk favorit" },
                    { 32, "Bittersöt favorit" },
                    { 33, "Martinivariant" },
                    { 34, "Juldrink" },
                    { 35, "Bitter sour" },
                    { 36, "Klassisk apertif" },
                    { 37, "Dessertdrink" },
                    { 38, "Klassisk bubbeldrink" },
                    { 39, "Gräddig dessertcocktail" },
                    { 40, "Rökig aperitivo" },
                    { 41, "Rökig aperitivo" },
                    { 42, "Rökig törstsläckare" },
                    { 43, "Bitter bubbeldrink" },
                    { 44, "Klassisk sommardrink" },
                    { 45, "Enkel longdrink" },
                    { 46, "Bittersöt törstsläckare" },
                    { 47, "Bittersöt longdrink" },
                    { 48, "Fruktig sour" },
                    { 49, "Karibisk klassiker" },
                    { 50, "Klassisk törstsläckare" },
                    { 51, "Tropisk tikidrink" },
                    { 52, "Elegant klassiker" },
                    { 53, "Amerikansk klassiker" },
                    { 54, "Läskande sommardrink" },
                    { 55, "Tropisk törstsläckare" },
                    { 56, "Potent kaffekick" },
                    { 57, "Rom och Cola 2.0" },
                    { 58, "Elegant brunchdrink" },
                    { 59, "Klassisk sour" },
                    { 60, "Trendig cocktail" },
                    { 61, "Fräsch strandfavorit" },
                    { 62, "Somrig favorit" },
                    { 63, "Klassisk återställare" },
                    { 64, "Klassisk brunchdrink" },
                    { 65, "Frisk sommarfavorit" },
                    { 66, "Kubas nationaldrink" },
                    { 67, "Bubblig Sommarfavorit" },
                    { 68, "Klassisk kaffedrink" }
                });

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "shaker" },
                    { 2, "citruspress" },
                    { 3, "rörglas" },
                    { 4, "barsked" },
                    { 5, "muddlare" },
                    { 6, "juicemaskin" },
                    { 7, "citrus" },
                    { 9, "rivjärn" },
                    { 10, "blender" },
                    { 11, "kastrull" },
                    { 12, "råsaftcentrifug" },
                    { 13, "swizzle stick eller barsked" },
                    { 14, "kniv" },
                    { 15, "swizzle stick/barsked" },
                    { 16, "tändstickor" },
                    { 17, "citrusskalare" },
                    { 18, "juicemaskin/citruspress" },
                    { 19, "kaffebryggare" },
                    { 20, "sked" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "cl" },
                    { 2, "st" },
                    { 4, "nypa" },
                    { 5, "stänk" },
                    { 6, "tsk" },
                    { 7, "cm" },
                    { 8, "bit" },
                    { 9, "droppar" },
                    { 10, "msk" },
                    { 11, "nypor" },
                    { 12, "flaska" },
                    { 13, "dl" },
                    { 14, "g" },
                    { 15, "stora" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flavour",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Garnish",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Glass",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Ingridient",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "HEX", "Name", "Prompt" },
                values: new object[] { 10, "#BCCDDE", "Grå", "Grey" });
        }
    }
}
