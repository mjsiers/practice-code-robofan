using Microsoft.EntityFrameworkCore.Migrations;

namespace RoboFan.Data.EFCore.Migrations
{
    public partial class SeedLeagueTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "LeagueTeam",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
