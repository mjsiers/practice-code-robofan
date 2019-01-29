using System;
using Xunit;
using RoboFan.Domain.Converters;
using RoboFan.Data.Mock.Generators;

namespace RoboFan.UnitTest.Converters
{
  public class RoboFanConverterTest
  {
    [Fact]
    public void ComputeAgeWhenFuture()
    {
      var currentdate = DateTime.Parse("07/01/2015");
      var birthdate = DateTime.Parse("07/02/2015");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(-1, age);
    }

    [Fact]
    public void ComputeAgeWhenPreviousMonth()
    {
      var currentdate = DateTime.Parse("07/01/2015");
      var birthdate = DateTime.Parse("06/01/2000");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(15, age);
    }

    [Fact]
    public void ComputeAgeWhenFutureMonth()
    {
      var currentdate = DateTime.Parse("07/01/2015");
      var birthdate = DateTime.Parse("08/01/2000");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(14, age);
    }

    [Fact]
    public void ComputeAgeWhenSameMonthPreviousDay()
    {
      var currentdate = DateTime.Parse("07/15/2015");
      var birthdate = DateTime.Parse("07/14/2000");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(15, age);
    }

    [Fact]
    public void ComputeAgeWhenSameMonthFutureDay()
    {
      var currentdate = DateTime.Parse("07/15/2015");
      var birthdate = DateTime.Parse("07/16/2000");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(14, age);
    }

    [Fact]
    public void ComputeAgeWhenSameMonthSameDay()
    {
      var currentdate = DateTime.Parse("07/15/2015");
      var birthdate = DateTime.Parse("07/15/2000");
      var age = RoboFanConverter.GetAge(birthdate, currentdate);
      Assert.Equal(15, age);
    }

    [Fact]
    public void VerifyRoboFanConverter()
    {
      var listfans = RoboFanGenerator.Generate(1, false, true);
      var fan = listfans[0];

      var model = RoboFanConverter.Convert(fan);
      Assert.Equal(fan.FirstName, model.FirstName);
      Assert.Equal(fan.LastName, model.LastName);
      Assert.Equal(fan.Address, model.Address);
      Assert.Equal(fan.City, model.City);
      Assert.Equal(fan.State, model.State);
      Assert.False(string.IsNullOrEmpty(model.ImageUrl));
      Assert.Equal(fan.PrimaryTeam.Name, model.TeamName);
      Assert.Equal(fan.PrimaryTeam.ImageUrl, model.TeamImageUrl);
      Assert.NotNull(model.PosTeams);
      Assert.NotNull(model.NegTeams);
      Assert.Equal(fan.FanRankings.Count, model.PosTeams.Count + model.NegTeams.Count);
    }
  }
}
