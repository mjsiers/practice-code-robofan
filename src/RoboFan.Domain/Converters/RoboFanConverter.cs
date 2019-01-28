using System.Collections.Generic;
using System.Linq;
using RoboFan.Domain.Entities;
using RoboFan.Domain.ViewModels;

namespace RoboFan.Domain.Converters
{
  public static class RoboFanConverter
  {
    public static RoboFanViewModel Convert(Entities.RoboFan robofan)
    {
      var result = new RoboFanViewModel();
      return result;
    }
  }
}
