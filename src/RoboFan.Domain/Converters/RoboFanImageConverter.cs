using RoboFan.Domain.Entities;
using RoboFan.Domain.ViewModels;

namespace RoboFan.Domain.Converters
{
  public static class RoboFanImageConverter
  {
    public static string ImageUrl(RoboFanImage fanimage)
    {
      string imageurl = string.Format("~/api/robofan/{0}/image", fanimage.Id);
      return imageurl;
    }
  }
}
