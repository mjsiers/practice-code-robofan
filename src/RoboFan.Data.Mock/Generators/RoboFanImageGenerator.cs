using System;
using System.Net;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;
using Serilog;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanImageGenerator
  {
    public static async Task<RoboFanImage> GenerateAsync(int robofanid, string imagepath)
    {
      // create and read one of the pre-generated robot images
      RoboFanImage fanimage = Create(robofanid);
      fanimage.ImageData = await ReadImageAsync(imagepath);

      return fanimage;
    }

    public static RoboFanImage Generate(int robofanid, string imagepath)
    {
      // create and read one of the pre-generated robot images
      RoboFanImage fanimage = Create(robofanid);
      fanimage.ImageData = ReadImage(imagepath);

      return fanimage;
    }

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

    public static RoboFanImage Fetch(int robofanid, string path)
    {
      // create and ensure we are requested to fetch the robot image
      RoboFanImage fanimage = Create(robofanid);
      fanimage.ImageData = ReadImage(path);

      return fanimage;
    }

    public static async Task<RoboFanImage> FetchAsync(int robofanid, string path)
    {
      // create and ensure we are requested to fetch the robot image
      RoboFanImage fanimage = Create(robofanid);
      fanimage.ImageData = await ReadImageAsync(path);

      return fanimage;
    }

    private const int MaxRobotId = 50; 

    private static byte[] ReadImage(string path, string filetype="png")
    {
      // generate a random index to use to select a specific robot image file
      Random randNum = new Random();
      var id = randNum.Next(MaxRobotId-1)+1;

      // determine image file name and ensure it exists
      string filename = string.Format("robot-{0}.{1}", id, filetype);
      string filepath = System.IO.Path.Combine(path, filename);
      if (!System.IO.File.Exists(filepath)) {
        Log.Warning("Robot image file does not exist [{0}]", filepath);
        return null;
      }

      return System.IO.File.ReadAllBytes(filepath);
    }

    private static async Task<byte[]> ReadImageAsync(string path, string filetype = "png")
    {
      // generate a random index to use to select a specific robot image file
      Random randNum = new Random();
      var id = randNum.Next(MaxRobotId - 1)+1;

      // determine image file name and ensure it exists
      string filename = string.Format("robot-{0}.{1}", id, filetype);
      string filepath = System.IO.Path.Combine(path, filename);
      if (!System.IO.File.Exists(filepath))
      {
        Log.Warning("Robot image file does not exist [{0}]", filepath);
        return null;
      }

      return await System.IO.File.ReadAllBytesAsync(filepath);
    }

    private static byte[] FetchImage(Guid id, int width, int height)
    {
      byte[] imagedata;

      // create web client to download robot images with
      using (var client = new WebClient())
      {
        // generate a random robot image using the robohash website and download the image data
        var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", id, width, height);
        imagedata = client.DownloadData(imageurl);
      }

      return imagedata;
    }

    private static async Task<byte[]> FetchImageAsync(Guid id, int width, int height)
    {
      byte[] imagedata;

      // create web client to download robot images with
      using (var client = new WebClient())
      {
        // generate a random robot image using the robohash website and download the image data
        var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", id, width, height);
        imagedata = client.DownloadData(imageurl);
        imagedata = await client.DownloadDataTaskAsync(imageurl);
      }

      return imagedata;
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
