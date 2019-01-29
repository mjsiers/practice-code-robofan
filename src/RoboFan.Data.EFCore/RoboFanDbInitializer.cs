using Microsoft.EntityFrameworkCore;
using Serilog;
using RoboFan.Data.Mock.Generators;

namespace RoboFan.Data.EFCore
{
  public class RoboFanDbInitializer
  {
    private readonly ILogger _log = Log.ForContext<RoboFanDbInitializer>();
    private readonly RoboFanContext _ctx;

    public RoboFanDbInitializer(RoboFanContext ctx)
    {
      _ctx = ctx;
    }

    public async void Seed()
    {
      // ensure the database exists and is upto to date first
      _log.Information("Migrating database (if needed).");
      _ctx.Database.Migrate();

      // ensure we have at least one fan record
      var fansexist = await _ctx.RoboFan.AnyAsync();
      if (!fansexist)
      {
        _log.Information("Generating new RoboFan records.");
        var listfans = RoboFanGenerator.Generate(1, true, true);
        foreach (var fan in listfans)
        {
          // save off the fan ranking values since we cannot add them until we know the record id
          // also clear out the primary team since the record already exists in db
          var fanrankings = fan.FanRankings;
          fan.FanRankings = null;
          fan.PrimaryTeam = null;

          // add the fan and image records to the database
          _ctx.RoboFan.Add(fan);
          foreach (var ranking in fanrankings)
          {
            // ensure the objects are null and ids are correct
            ranking.LeagueTeam = null;
            ranking.RobotFan = null;
            ranking.RobotFanId = fan.Id;

            // save the ranking record
            _ctx.RoboFanTeamRanking.Add(ranking);
          }

          // commit all the updates to the database
          _ctx.SaveChanges();
        }
      }
    }
  }
}
