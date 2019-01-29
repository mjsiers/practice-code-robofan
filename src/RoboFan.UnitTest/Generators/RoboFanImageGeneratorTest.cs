using Xunit;
using RoboFan.Data.Mock.Generators;
using System;

namespace RoboFan.UnitTest.Generators
{
  public class RoboFanImageGeneratorTest
  {
    [Fact]
    public void VerifyRoboFanImageGenerator()
    {
      const int fanid = 1;
      Guid guidResult;

      // disabled image generation to ensure test runs fast
      var fanimage = RoboFanImageGenerator.Generate(fanid, false);
      Assert.NotNull(fanimage);
      Assert.Equal(fanid, fanimage.RoboFanId);
      Assert.True(Guid.TryParse(fanimage.GuidId.ToString(), out guidResult));
      Assert.NotNull(fanimage.ContentType);
      //Assert.NotNull(fanimage.ImageData);
    }
  }
}
