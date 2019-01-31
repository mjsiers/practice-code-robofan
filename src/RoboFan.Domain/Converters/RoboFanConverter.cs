using System;
using System.Collections.Generic;
using System.Linq;
using RoboFan.Domain.ViewModels;

namespace RoboFan.Domain.Converters
{
  public static class RoboFanConverter
  {
    public static List<RoboFanViewModel> ConvertList(List<Entities.RoboFan> listfans, string hostpath = null)
    {
      List<RoboFanViewModel> listmodels = new List<RoboFanViewModel>();

      // loop over all the fans and convert each one
      foreach (var fan in listfans)
      {
        var model = Convert(fan, hostpath);
        listmodels.Add(model);
      }

      return listmodels;
    }

    public static RoboFanViewModel Convert(Entities.RoboFan robofan, string hostpath = null)
    {
      // initialize a new fan view model
      // todo: look into setting up AutoMapper?
      var model = new RoboFanViewModel();
      model.Id = robofan.Id;
      model.FirstName = robofan.FirstName;
      model.LastName = robofan.LastName;
      model.Address = robofan.Address;
      model.City = robofan.City;
      model.State = robofan.State;
      model.TeamName = robofan.PrimaryTeam.Name;
      model.TeamImageUrl = robofan.PrimaryTeam.ImageUrl;
      model.ImageUrl = RoboFanImageConverter.ImageUrl(robofan.RoboFanImage, hostpath);
  
      // update the team image path if specified
      if (!string.IsNullOrEmpty(hostpath))
      {
        // for client the image path must be the full URL
        var filename = System.IO.Path.GetFileName(model.TeamImageUrl);
        model.TeamImageUrl = string.Format("{0}/images/teams/{1}", hostpath, filename);
      }

      // default the view model birthdate and age values
      model.Age = GetAge(robofan.BirthDate, DateTime.Now);
      model.BirthDate = robofan.BirthDate?.Date.ToString("MM/dd/yyyy");

      // execute query to get the list of positive ranked teams for this fan
      model.PosTeams = (from ranking in robofan.FanRankings
                        where ((ranking.Ranking > 0) && (ranking.RobotFanId == robofan.Id))
                        orderby ranking.LeagueTeam.Name ascending
                        select ranking.LeagueTeam.Name).ToList<string>();

      // execute query to get the list of negative ranked teams for this fan
      model.NegTeams = (from ranking in robofan.FanRankings
                        where ((ranking.Ranking < 0) && (ranking.RobotFanId == robofan.Id))
                        orderby ranking.LeagueTeam.Name ascending
                        select ranking.LeagueTeam.Name).ToList<string>();

      return model;
    }

    public static int GetAge(DateTime? birthDate, DateTime fromdateTime)
    {
      int age = -1;

      // ensure birthdate is valid
      if (birthDate.HasValue)
      {
        // compute the different in years
        age = fromdateTime.Year - birthDate.Value.Year;

        // reduce age value if current month or day precedes the birth date value
        if (fromdateTime.Month < birthDate.Value.Month || (fromdateTime.Month == birthDate.Value.Month && fromdateTime.Day < birthDate.Value.Day))
        {
          age--;
        }
      }

      return age;
    }
  }
}
