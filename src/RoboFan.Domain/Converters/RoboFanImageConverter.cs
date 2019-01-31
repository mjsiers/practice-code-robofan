using RoboFan.Domain.Entities;

namespace RoboFan.Domain.Converters
{
  public static class RoboFanImageConverter
  {
    public static string ImageUrl(RoboFanImage fanimage, string hostpath = null)
    {
      string imageurl;

      // determine if the hostpath was specified
      if (!string.IsNullOrEmpty(hostpath))
      {
        // build up a full URL path for the image
        imageurl = string.Format("{0}/api/robofan/{1}/image", hostpath, fanimage.Id);
      }
      else {
        // build up a relative path for the image
        imageurl = string.Format("~/api/robofan/{0}/image", fanimage.Id);
      }

      return imageurl;
    }
  }
}
