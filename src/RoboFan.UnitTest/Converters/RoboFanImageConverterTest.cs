using System;
using RoboFan.Data.Mock.Generators;
using RoboFan.Domain.Converters;
using Xunit;

namespace RoboFan.UnitTest.Converters
{
  public class RoboFanImageConverterTest
  {
    [Fact]
    public void VerifyRoboFanImageConverter()
    {
      const int fanid = 1;
      var fanimage = RoboFanImageGenerator.Generate(fanid, false);
      var imageurl = RoboFanImageConverter.ImageUrl(fanimage);
      Assert.NotNull(imageurl);
      Assert.Contains(fanimage.Id.ToString(), imageurl);
    }
  }
}
