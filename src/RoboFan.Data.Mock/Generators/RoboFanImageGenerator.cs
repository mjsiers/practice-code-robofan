using System;
using System.Net;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanImageGenerator
  {
    public static async Task<RoboFanImage> GenerateAsync(int robofanid, bool fetchImage = true)
    {
      // create and ensure we are requested to fetch the robot image
      RoboFanImage fanimage = Create(robofanid);
      if (fetchImage)
      {
        // create web client to download robot images with
        using (var client = new WebClient())
        {
          // generate a random robot image using the robohash website and download the image data
          var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", fanimage.GuidId, fanimage.Width, fanimage.Height);
          fanimage.ImageData = await client.DownloadDataTaskAsync(imageurl);
        }
      }

      return fanimage;
    }

    public static RoboFanImage Generate(int robofanid, bool fetchImage = true)
    {
      // create and ensure we are requested to fetch the robot image
      RoboFanImage fanimage = Create(robofanid);
      if (fetchImage)
      {
        // create web client to download robot images with
        using (var client = new WebClient())
        {
          // generate a random robot image using the robohash website and download the image data
          var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", fanimage.GuidId, fanimage.Width, fanimage.Height);
          fanimage.ImageData = client.DownloadData(imageurl);
        }
      }

      return fanimage;
    }

    private static RoboFanImage Create(int robofanid)
    {
      const int imgwidth = 80;
      const int imgheight = 80;

      // create and initialize the values
      RoboFanImage fanimage = new RoboFanImage();
      fanimage.Id = robofanid;
      fanimage.GuidId = Guid.NewGuid();
      fanimage.Width = imgwidth;
      fanimage.Height = imgheight;
      fanimage.ContentType = "image/png";
      fanimage.RoboFanId = robofanid;

      return fanimage;
    }
  }
}
