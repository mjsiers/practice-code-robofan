using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.EFCore.Configuration
{
  public class LeagueTeamConfiguration
  {
    public LeagueTeamConfiguration(EntityTypeBuilder<LeagueTeam> entity)
    {
      entity.Property(e => e.Name).HasMaxLength(64).IsRequired();
      entity.Property(e => e.Conference).HasMaxLength(64).IsRequired();
      entity.Property(e => e.ImageUrl).HasMaxLength(128).IsRequired();

      // since this information is mainly static going to seed the database table here
      entity.HasData(new LeagueTeam(1, "Atlanta United FC", "Eastern", "~/images/teams/atlantaunitedfc.gif"));
      entity.HasData(new LeagueTeam(2, "Chicago Fire", "Eastern", "~/images/teams/chicagofire.gif"));
      entity.HasData(new LeagueTeam(3, "Colorado Rapids", "Western", "~/images/teams/coloradorapids.gif"));
      entity.HasData(new LeagueTeam(4, "Columbus Crew SC", "Eastern", "~/images/teams/columbuscrewsc.gif"));
      entity.HasData(new LeagueTeam(5, "D.C. United", "Eastern", "~/images/teams/dcunited.gif"));
      entity.HasData(new LeagueTeam(6, "FC Cincinnati", "Eastern", "~/images/teams/fccincinnati.gif"));
      entity.HasData(new LeagueTeam(7, "FC Dallas", "Western", "~/images/teams/fcdallas.gif"));
      entity.HasData(new LeagueTeam(8, "Houston Dynamo", "Western", "~/images/teams/houstondynamo.gif"));
      entity.HasData(new LeagueTeam(9, "LA Galaxy", "Western", "~/images/teams/lagalaxy.gif"));
      entity.HasData(new LeagueTeam(10, "Los Angeles FC", "Western", "~/images/teams/losangelesfc.gif"));
      entity.HasData(new LeagueTeam(11, "Minnesota United FC", "Western", "~/images/teams/minnesotaunitedfc.gif"));
      entity.HasData(new LeagueTeam(12, "Montreal Impact", "Eastern", "~/images/teams/montrealimpact.gif"));
      entity.HasData(new LeagueTeam(13, "New England Revolution", "Eastern", "~/images/teams/newenglandrevolution.gif"));
      entity.HasData(new LeagueTeam(14, "New York City FC", "Eastern", "~/images/teams/newyorkcityfc.gif"));
      entity.HasData(new LeagueTeam(15, "New York Red Bulls", "Eastern", "~/images/teams/newyorkredbulls.gif"));
      entity.HasData(new LeagueTeam(16, "Orlando City SC", "Eastern", "~/images/teams/orlandocitysc.gif"));
      entity.HasData(new LeagueTeam(17, "Philadelphia Union", "Eastern", "~/images/teams/philadelphiaunion.gif"));
      entity.HasData(new LeagueTeam(18, "Portland Timbers", "Western", "~/images/teams/portlandtimbers.gif"));
      entity.HasData(new LeagueTeam(19, "Real Salt Lake", "Western", "~/images/teams/realsaltlake.gif"));
      entity.HasData(new LeagueTeam(20, "San Jose Earthquakes", "Western", "~/images/teams/sanjoseearthquakes.gif"));
      entity.HasData(new LeagueTeam(21, "Seattle Sounders FC", "Western", "~/images/teams/seattlesoundersfc.gif"));
      entity.HasData(new LeagueTeam(22, "Sporting Kansas City", "Western", "~/images/teams/sportingkansascity.gif"));
      entity.HasData(new LeagueTeam(23, "Toronto FC", "Eastern", "~/images/teams/torontofc.gif"));
      entity.HasData(new LeagueTeam(24, "Vancouver Whitecaps FC", "Western", "~/images/teams/vancouverwhitecapsfc.gif"));
    }
  }
}
