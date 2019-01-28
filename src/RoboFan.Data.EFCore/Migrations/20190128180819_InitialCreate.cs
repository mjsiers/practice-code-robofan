using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoboFan.Data.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Conference = table.Column<string>(maxLength: 64, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoboFan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuidId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Address = table.Column<string>(maxLength: 128, nullable: false),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    State = table.Column<string>(maxLength: 64, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    PrimaryTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoboFan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoboFan_LeagueTeam_PrimaryTeamId",
                        column: x => x.PrimaryTeamId,
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoboFanTeamRanking",
                columns: table => new
                {
                    RobotFanId = table.Column<int>(nullable: false),
                    LeagueTeamId = table.Column<int>(nullable: false),
                    Ranking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoboFanTeamRanking", x => new { x.RobotFanId, x.LeagueTeamId });
                    table.ForeignKey(
                        name: "FK_RoboFanTeamRanking_LeagueTeam_LeagueTeamId",
                        column: x => x.LeagueTeamId,
                        principalTable: "LeagueTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoboFanTeamRanking_RoboFan_RobotFanId",
                        column: x => x.RobotFanId,
                        principalTable: "RoboFan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoboFan_PrimaryTeamId",
                table: "RoboFan",
                column: "PrimaryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RoboFanTeamRanking_LeagueTeamId",
                table: "RoboFanTeamRanking",
                column: "LeagueTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoboFanTeamRanking");

            migrationBuilder.DropTable(
                name: "RoboFan");

            migrationBuilder.DropTable(
                name: "LeagueTeam");
        }
    }
}
