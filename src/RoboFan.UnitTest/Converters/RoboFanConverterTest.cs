using System;
using Xunit;
using RoboFan.Domain.Converters;

namespace RoboFan.UnitTest.Converters
{
  public class RoboFanConverterTest
  {
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
  }
}
