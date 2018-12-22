using Microsoft.EntityFrameworkCore.Migrations;

namespace hearthStoneDeckBuilder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: false),
                    ClassType = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LinkPicture = table.Column<string>(nullable: true),
                    CardClass = table.Column<int>(nullable: false),
                    Rarity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    deckID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Card_Deck_deckID",
                        column: x => x.deckID,
                        principalTable: "Deck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_deckID",
                table: "Card",
                column: "deckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");
        }
    }
}
