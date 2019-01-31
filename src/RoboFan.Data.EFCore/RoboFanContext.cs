using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Entities;
using RoboFan.Data.EFCore.Configuration;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

// link to some documentation on how to perform databasse migrations
//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
//  dotnet ef migrations add <name>
//  dotnet ef migrations remove
//  dotnet ef database update

namespace RoboFan.Data.EFCore
{
  public class RoboFanContext : DbContext
  {
    public virtual DbSet<LeagueTeam> LeagueTeam { get; set; }
    public virtual DbSet<RoboFanEntity> RoboFan { get; set; }
    public virtual DbSet<RoboFanImage> RoboFanImage { get; set; }
    public virtual DbSet<RoboFanTeamRanking> RoboFanTeamRanking { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // for now just use hard coded connection string
      // todo: get this from the configuration file and ensure we support in memory databases for unit testing
      optionsBuilder.UseSqlite("Data Source=RoboFanDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // ensure the entities configurations are updated
      var cfgRoboFan = new RoboFanConfiguration(modelBuilder.Entity<RoboFanEntity>());
      var cfgRoboFanImage = new RoboFanImageConfiguration(modelBuilder.Entity<RoboFanImage>());
      var cfgLeagueTeam = new LeagueTeamConfiguration(modelBuilder.Entity<LeagueTeam>());

      // configure the one-to-one relationship table with cascading deletes
      modelBuilder.Entity<RoboFanEntity>()
          .HasOne(a => a.RoboFanImage)
          .WithOne()
          .HasForeignKey<RoboFanImage>(b => b.RoboFanId)
          .OnDelete(DeleteBehavior.Cascade);
     
      // configure the many-to-many relationship table with cascading deletes
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasKey(tr => new { tr.RobotFanId, tr.LeagueTeamId });
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasOne<RoboFanEntity>()
          .WithMany(rf => rf.FanRankings)
          .HasForeignKey(rf => rf.RobotFanId)
          .OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<RoboFanTeamRanking>()
          .HasOne(tr => tr.LeagueTeam)
          .WithMany()
          .HasForeignKey(lt => lt.LeagueTeamId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
