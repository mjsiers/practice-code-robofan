using Xunit;
using RoboFan.Data.Mock.Generators;
using System;

namespace RoboFan.UnitTest.Generators
{
  public class RoboFanGeneratorTest
  {
    [Fact]
    public void VerifyRoboFanGenerator()
    {
      var listfans = RoboFanGenerator.Generate(1);
      Assert.NotNull(listfans);
      Assert.Single(listfans);


      var fan = listfans[0];

      Assert.NotEmpty(fan.FirstName);
      Assert.NotEmpty(fan.LastName);
      Assert.NotEmpty(fan.Address);
      Assert.NotEmpty(fan.City);
      Assert.NotEmpty(fan.State);
      Assert.NotNull(fan.BirthDate);
      Assert.NotNull(fan.PrimaryTeamId);
      Assert.InRange<int>((int)fan.PrimaryTeamId, 1, 24);
    }
  }
}
