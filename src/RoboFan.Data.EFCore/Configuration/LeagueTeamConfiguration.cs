using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboFan.Domain.Entities;
using RoboFan.Data.Mock.Generators;


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
      var listteams = LeagueTeamGenerator.Generate();
      foreach(var team in listteams)
      {
        entity.HasData(team);
      }
    }
  }
}
