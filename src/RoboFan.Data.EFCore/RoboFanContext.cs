using System.Threading;
using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Entities;
using RoboFan.Data.EFCore.Configuration;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Data.EFCore
{
  // link to documentation on how to perform migrations
  //https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
  //  dotnet ef migrations add <name>
  //  dotnet ef migrations remove
  //  dotnet ef database update

  public class RoboFanContext : DbContext
  {
    public virtual DbSet<RoboFan.Domain.Entities.RoboFan> RoboFan { get; set; }
    public virtual DbSet<LeagueTeam> LeagueTeam { get; set; }
    public virtual DbSet<RoboFanTeamRanking> RoboFanTeamRanking { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=RoboFanDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // ensure the entities configurations are updated
      var cfgRoboFan = new RoboFanConfiguration(modelBuilder.Entity<RoboFanEntity>());
      var cfgLeagueTeam = new LeagueTeamConfiguration(modelBuilder.Entity<LeagueTeam>());

      // configure the one-to-one relationship table
      modelBuilder.Entity<RoboFanEntity>()
          .HasOne(a => a.RoboFanImage)
          .WithOne(b => b.RoboFan)
          .HasForeignKey<RoboFanImage>(b => b.RoboFanId);

      // configure the many-to-many relationship table
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasKey(tr => new { tr.RobotFanId, tr.LeagueTeamId });
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasOne(tr => tr.RobotFan)
          .WithMany(rf => rf.FanRankings)
          .HasForeignKey(rf => rf.RobotFanId);
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasOne(tr => tr.LeagueTeam)
          .WithMany(lt => lt.FanRankings)
          .HasForeignKey(lt => lt.LeagueTeamId);
    }
  }
}
