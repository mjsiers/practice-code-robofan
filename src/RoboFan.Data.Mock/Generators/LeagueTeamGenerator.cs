using System.Collections.Generic;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.Mock.Generators
{
  public static class LeagueTeamGenerator
  {
    public static List<LeagueTeam> Generate()
    {
      List<LeagueTeam> listteams = new List<LeagueTeam>();

      // since this information is mainly static going to just use real values in the generator
      // todo: probably better to support reading this data in from the CSV file
      listteams.Add(new LeagueTeam(1, "Atlanta United FC", "Eastern", "~/images/teams/atlantaunitedfc.gif"));
      listteams.Add(new LeagueTeam(2, "Chicago Fire", "Eastern", "~/images/teams/chicagofire.gif"));
      listteams.Add(new LeagueTeam(3, "Colorado Rapids", "Western", "~/images/teams/coloradorapids.gif"));
      listteams.Add(new LeagueTeam(4, "Columbus Crew SC", "Eastern", "~/images/teams/columbuscrewsc.gif"));
      listteams.Add(new LeagueTeam(5, "D.C. United", "Eastern", "~/images/teams/dcunited.gif"));
      listteams.Add(new LeagueTeam(6, "FC Cincinnati", "Eastern", "~/images/teams/fccincinnati.gif"));
      listteams.Add(new LeagueTeam(7, "FC Dallas", "Western", "~/images/teams/fcdallas.gif"));
      listteams.Add(new LeagueTeam(8, "Houston Dynamo", "Western", "~/images/teams/houstondynamo.gif"));
      listteams.Add(new LeagueTeam(9, "LA Galaxy", "Western", "~/images/teams/lagalaxy.gif"));
      listteams.Add(new LeagueTeam(10, "Los Angeles FC", "Western", "~/images/teams/losangelesfc.gif"));
      listteams.Add(new LeagueTeam(11, "Minnesota United FC", "Western", "~/images/teams/minnesotaunitedfc.gif"));
      listteams.Add(new LeagueTeam(12, "Montreal Impact", "Eastern", "~/images/teams/montrealimpact.gif"));
      listteams.Add(new LeagueTeam(13, "New England Revolution", "Eastern", "~/images/teams/newenglandrevolution.gif"));
      listteams.Add(new LeagueTeam(14, "New York City FC", "Eastern", "~/images/teams/newyorkcityfc.gif"));
      listteams.Add(new LeagueTeam(15, "New York Red Bulls", "Eastern", "~/images/teams/newyorkredbulls.gif"));
      listteams.Add(new LeagueTeam(16, "Orlando City SC", "Eastern", "~/images/teams/orlandocitysc.gif"));
      listteams.Add(new LeagueTeam(17, "Philadelphia Union", "Eastern", "~/images/teams/philadelphiaunion.gif"));
      listteams.Add(new LeagueTeam(18, "Portland Timbers", "Western", "~/images/teams/portlandtimbers.gif"));
      listteams.Add(new LeagueTeam(19, "Real Salt Lake", "Western", "~/images/teams/realsaltlake.gif"));
      listteams.Add(new LeagueTeam(20, "San Jose Earthquakes", "Western", "~/images/teams/sanjoseearthquakes.gif"));
      listteams.Add(new LeagueTeam(21, "Seattle Sounders FC", "Western", "~/images/teams/seattlesoundersfc.gif"));
      listteams.Add(new LeagueTeam(22, "Sporting Kansas City", "Western", "~/images/teams/sportingkansascity.gif"));
      listteams.Add(new LeagueTeam(23, "Toronto FC", "Eastern", "~/images/teams/torontofc.gif"));
      listteams.Add(new LeagueTeam(24, "Vancouver Whitecaps FC", "Western", "~/images/teams/vancouverwhitecapsfc.gif"));

      return listteams;
    }
  }
}
