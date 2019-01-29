using Xunit;
using RoboFan.Data.Mock.Generators;
using System;

namespace RoboFan.UnitTest.Generators
{
  public class RoboFanGeneratorTest
  {
    [Fact]
    public void VerifyGeneratorRoboFan()
    {
      var listfans = RoboFanGenerator.Generate(1);
      Assert.NotNull(listfans);
      Assert.Single(listfans);

      //Guid guidResult;
      var fan = listfans[0];
      //Assert.True(Guid.TryParse(fan.GuidId.ToString(), out guidResult));
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
