﻿using System;
using System.Net;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanImageGenerator
  {
    public static RoboFanImage Generate(int robofanid)
    {
      const int imgwidth = 100;
      const int imgheight = 100;
      RoboFanImage fanimage = new RoboFanImage();

      fanimage.GuidId = Guid.NewGuid();
      fanimage.Width = imgwidth;
      fanimage.Height = imgheight;
      fanimage.ContentType = "image/png";
      fanimage.RoboFanId = robofanid;

      // create web client to download robot images with
      using (var client = new WebClient())
      {
        // generate a random robot image using the robohash website and download the image data
        var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", fanimage.GuidId, imgwidth, imgheight);
        fanimage.ImageData = client.DownloadData(imageurl);
      }

      return fanimage;
    }
  }
}
