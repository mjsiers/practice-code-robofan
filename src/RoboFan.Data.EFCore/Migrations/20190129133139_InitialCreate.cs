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
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Address = table.Column<string>(maxLength: 128, nullable: false),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    State = table.Column<string>(maxLength: 64, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DateTime2", nullable: true),
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
                name: "RoboFanImage",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 64, nullable: false),
                    ImageData = table.Column<byte[]>(nullable: true),
                    RoboFanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoboFanImage", x => x.GuidId);
                    table.ForeignKey(
                        name: "FK_RoboFanImage_RoboFan_RoboFanId",
                        column: x => x.RoboFanId,
                        principalTable: "RoboFan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 1, "Eastern", "~/images/teams/atlantaunitedfc.gif", "Atlanta United FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 22, "Western", "~/images/teams/sportingkansascity.gif", "Sporting Kansas City" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 21, "Western", "~/images/teams/seattlesoundersfc.gif", "Seattle Sounders FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 20, "Western", "~/images/teams/sanjoseearthquakes.gif", "San Jose Earthquakes" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 19, "Western", "~/images/teams/realsaltlake.gif", "Real Salt Lake" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 18, "Western", "~/images/teams/portlandtimbers.gif", "Portland Timbers" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 17, "Eastern", "~/images/teams/philadelphiaunion.gif", "Philadelphia Union" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 16, "Eastern", "~/images/teams/orlandocitysc.gif", "Orlando City SC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 15, "Eastern", "~/images/teams/newyorkredbulls.gif", "New York Red Bulls" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 14, "Eastern", "~/images/teams/newyorkcityfc.gif", "New York City FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 13, "Eastern", "~/images/teams/newenglandrevolution.gif", "New England Revolution" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 12, "Eastern", "~/images/teams/montrealimpact.gif", "Montreal Impact" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 11, "Western", "~/images/teams/minnesotaunitedfc.gif", "Minnesota United FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 10, "Western", "~/images/teams/losangelesfc.gif", "Los Angeles FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 9, "Western", "~/images/teams/lagalaxy.gif", "LA Galaxy" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 8, "Western", "~/images/teams/houstondynamo.gif", "Houston Dynamo" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 7, "Western", "~/images/teams/fcdallas.gif", "FC Dallas" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 6, "Eastern", "~/images/teams/fccincinnati.gif", "FC Cincinnati" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 5, "Eastern", "~/images/teams/dcunited.gif", "D.C. United" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 4, "Eastern", "~/images/teams/columbuscrewsc.gif", "Columbus Crew SC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 3, "Western", "~/images/teams/coloradorapids.gif", "Colorado Rapids" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 2, "Eastern", "~/images/teams/chicagofire.gif", "Chicago Fire" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 23, "Eastern", "~/images/teams/torontofc.gif", "Toronto FC" });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "Id", "Conference", "ImageUrl", "Name" },
                values: new object[] { 24, "Western", "~/images/teams/vancouverwhitecapsfc.gif", "Vancouver Whitecaps FC" });

            migrationBuilder.CreateIndex(
                name: "IX_RoboFan_PrimaryTeamId",
                table: "RoboFan",
                column: "PrimaryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RoboFanImage_RoboFanId",
                table: "RoboFanImage",
                column: "RoboFanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoboFanTeamRanking_LeagueTeamId",
                table: "RoboFanTeamRanking",
                column: "LeagueTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoboFanImage");

            migrationBuilder.DropTable(
                name: "RoboFanTeamRanking");

            migrationBuilder.DropTable(
                name: "RoboFan");

            migrationBuilder.DropTable(
                name: "LeagueTeam");
        }
    }
}
