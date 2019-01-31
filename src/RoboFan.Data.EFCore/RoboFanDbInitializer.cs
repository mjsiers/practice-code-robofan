using Microsoft.EntityFrameworkCore;
using RoboFan.Data.EFCore.Repositories;
using RoboFan.Data.Mock.Generators;
using Serilog;

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

    public async void Seed(string path, int numfans = 3)
    {
      // ensure the database exists and is upto to date first
      _log.Information("Migrating database (if needed).");
      _ctx.Database.Migrate();

      // ensure we have at least one fan record
      var fanexist = await _ctx.RoboFan.AnyAsync();
      if (!fanexist)
      {
        // no fans are in the database
        // generate some new fans and save using the repository
        _log.Information("Seeding database with [{0}] new fans.", numfans);
        var repository = new RoboFanRepository(_ctx);
        var listfans = RoboFanGenerator.Generate(numfans, path, true);
        var status = await repository.AddManyAsync(listfans);
      }
    }
  }
}
