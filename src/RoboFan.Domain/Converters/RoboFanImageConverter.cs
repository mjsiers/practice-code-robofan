using RoboFan.Domain.Entities;
using RoboFan.Domain.ViewModels;

namespace RoboFan.Domain.Converters
{
  public static class RoboFanImageConverter
  {
    public static string ImageUrl(RoboFanImage fanimage, string hostpath = null)
    {
      string imageurl;

      if (!string.IsNullOrEmpty(hostpath))
      {
        imageurl = string.Format("{0}/api/robofan/{1}/image", hostpath, fanimage.Id);
      }
      else {
        imageurl = string.Format("~/api/robofan/{0}/image", fanimage.Id);
      }

      return imageurl;
    }
  }
}
