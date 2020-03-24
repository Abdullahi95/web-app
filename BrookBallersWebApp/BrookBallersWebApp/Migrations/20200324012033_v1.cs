using Microsoft.EntityFrameworkCore.Migrations;

namespace BrookBallersWebApp.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    MP = table.Column<int>(nullable: false),
                    W = table.Column<int>(nullable: false),
                    D = table.Column<int>(nullable: false),
                    L = table.Column<int>(nullable: false),
                    GF = table.Column<int>(nullable: false),
                    GA = table.Column<int>(nullable: false),
                    GD = table.Column<int>(nullable: false),
                    PTS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Pos = table.Column<string>(nullable: false),
                    Foot = table.Column<string>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    TGA = table.Column<int>(nullable: false),
                    Apps = table.Column<int>(nullable: false),
                    Yel = table.Column<int>(nullable: false),
                    Red = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "D", "GA", "GD", "GF", "L", "MP", "PTS", "TeamName", "W" },
                values: new object[,]
                {
                    { 1, 1, 52, 38, 16, 0, 10, 28, "Tekk Republic", 9 },
                    { 6, 1, 67, -45, 22, 8, 10, 4, "L.Hermanos", 1 },
                    { 2, 0, 33, 19, 52, 3, 10, 21, "AR FC", 7 },
                    { 5, 0, 64, -32, 32, 7, 10, 9, "Eagles United", 3 },
                    { 3, 1, 39, 5, 44, 5, 10, 13, "Hurli FC", 4 },
                    { 4, 1, 30, 15, 45, 5, 10, 13, "Akdem FC", 4 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Age", "Apps", "Assists", "Foot", "Goals", "PlayerName", "Pos", "Red", "TGA", "TeamID", "Yel" },
                values: new object[] { 1, 24, 7, 6, "R", 4, "Hassan A", "M", 0, 10, 1, 0 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Age", "Apps", "Assists", "Foot", "Goals", "PlayerName", "Pos", "Red", "TGA", "TeamID", "Yel" },
                values: new object[] { 2, 25, 10, 2, "R", 3, "Mohammed H", "F", 0, 5, 6, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
