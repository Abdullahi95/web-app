using Microsoft.EntityFrameworkCore.Migrations;

namespace BrookBallersWebApp.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LTeam = table.Column<string>(nullable: true),
                    MP = table.Column<int>(maxLength: 10, nullable: false),
                    W = table.Column<int>(maxLength: 10, nullable: false),
                    D = table.Column<int>(maxLength: 10, nullable: false),
                    L = table.Column<int>(maxLength: 10, nullable: false),
                    GF = table.Column<int>(nullable: false),
                    GA = table.Column<int>(nullable: false),
                    GD = table.Column<int>(nullable: false),
                    PTS = table.Column<int>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.LeagueID);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    TContributions = table.Column<int>(nullable: false),
                    Apps = table.Column<int>(nullable: false),
                    Yel = table.Column<int>(nullable: false),
                    Red = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(nullable: true),
                    TCaptain = table.Column<string>(nullable: true),
                    LeagueID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_League_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "League",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Restrict);
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
                    ShirtNum = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "LeagueID", "D", "GA", "GD", "GF", "L", "LTeam", "MP", "PTS", "W" },
                values: new object[,]
                {
                    { 1, 1, 52, 38, 16, 0, "Tekk Republic", 10, 28, 9 },
                    { 6, 1, 67, -45, 22, 8, "L.Hermanos", 10, 4, 1 },
                    { 2, 0, 33, 19, 52, 3, "AR FC", 10, 21, 7 },
                    { 5, 0, 64, -32, 32, 7, "Eagles United", 10, 9, 3 },
                    { 3, 1, 39, 5, 44, 5, "Hurli FC", 10, 13, 4 },
                    { 4, 1, 30, 15, 45, 5, "Akdem FC", 10, 13, 4 }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "StatID", "Apps", "Assists", "Goals", "Red", "TContributions", "Yel" },
                values: new object[,]
                {
                    { 1, 7, 6, 4, 0, 10, 0 },
                    { 2, 10, 2, 3, 0, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "LeagueID", "TCaptain", "TName" },
                values: new object[,]
                {
                    { 1, 1, "Tariq", "Tekk Republic" },
                    { 6, 6, "Mohammed H", "Locos Hermanos" },
                    { 2, 2, "Zak Y", "AR FC" },
                    { 5, 5, "//", "Eagles United" },
                    { 3, 3, "Keyton", "Hurli FC" },
                    { 4, 4, "//", "Akdem" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Age", "Foot", "PlayerName", "Pos", "ShirtNum", "StatID", "TeamID" },
                values: new object[] { 1, 24, "R", "Hassan A", "M", 6, 1, 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Age", "Foot", "PlayerName", "Pos", "ShirtNum", "StatID", "TeamID" },
                values: new object[] { 2, 25, "R", "Mohammed H", "F", 9, 2, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatID",
                table: "Players",
                column: "StatID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueID",
                table: "Teams",
                column: "LeagueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
