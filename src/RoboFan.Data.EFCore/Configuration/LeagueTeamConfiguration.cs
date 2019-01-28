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
    }
  }
}
