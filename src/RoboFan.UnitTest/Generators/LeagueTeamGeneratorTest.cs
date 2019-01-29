using Xunit;
using RoboFan.Data.Mock.Generators;
using System;

namespace RoboFan.UnitTest.Generators
{
  public class LeagueTeamGeneratorTest
  {
    [Fact]
    public void VerifyLeagueTeamGenerator()
    {
      var listteams = LeagueTeamGenerator.Generate();
      Assert.NotNull(listteams);
      Assert.Equal(24, listteams.Count);
    }
  }
}
