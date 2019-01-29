using Xunit;
using RoboFan.Data.Mock.Generators;
using System;

namespace RoboFan.UnitTest.Generators
{
  public class RoboFanTeamRankingsGeneratorTest
  {
    [Fact]
    public void VerifyRoboFanTeamRankingsGenerator()
    {
      // generate list of teams and single robo fan
      var listfans = RoboFanGenerator.Generate(1, false, true);
      var robofan = listfans[0];

      // generate and validate the fan team rankings
      Assert.NotNull(robofan.FanRankings);
      foreach (var ranking in robofan.FanRankings)
      {
        Assert.Equal(robofan.Id, ranking.RobotFanId);
        Assert.NotEqual(robofan.PrimaryTeamId, ranking.LeagueTeamId);
        Assert.NotEqual(0, ranking.Ranking);
      }
    }
  }
}
