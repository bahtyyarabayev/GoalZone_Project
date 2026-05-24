using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalZonePremierLig.Web.Api.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixtureId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    BallPossession = table.Column<double>(type: "float", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    ShotsOnTarget = table.Column<int>(type: "int", nullable: false),
                    Passes = table.Column<int>(type: "int", nullable: false),
                    AccuratePasses = table.Column<int>(type: "int", nullable: false),
                    Corners = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    Offsides = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "FixtureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_FixtureId",
                table: "Statistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamId",
                table: "Statistics",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
