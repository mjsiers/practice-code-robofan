﻿using System;
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
      var model = new RoboFanViewModel();
      model.Id = robofan.Id;
      model.GuidId = robofan.GuidId;
      model.FirstName = robofan.FirstName;
      model.LastName = robofan.LastName;
      model.Address = robofan.Address;
      model.City = robofan.City;
      model.State = robofan.State;
      model.TeamName = robofan.PrimaryTeam.Name;
      model.TeamImageUrl = robofan.PrimaryTeam.ImageUrl;

      // default the view model birthdate and age values
      model.Age = GetAge(robofan.BirthDate);
      model.BirthDate = robofan.BirthDate?.Date.ToString();

      // execute query to get the positive ranked teams for this fan
      model.PosTeams = (from ranking in robofan.FanRankings
                        where ((ranking.Ranking > 0) && (ranking.RobotFanId == robofan.Id))
                        orderby ranking.LeagueTeam.Name ascending
                        select ranking.LeagueTeam.Name).ToList<string>();

      // execute query to get the negative ranked teams for this fan
      model.NegTeams = (from ranking in robofan.FanRankings
                        where ((ranking.Ranking < 0) && (ranking.RobotFanId == robofan.Id))
                        orderby ranking.LeagueTeam.Name ascending
                        select ranking.LeagueTeam.Name).ToList<string>();

      // todo: handle image as URL or data?
      //model.FanImageUrl = robofan.I

      return model;
    }

    public static int GetAge(DateTime? birthDate)
    {
      int age = -1;
      DateTime n = DateTime.Now;

      // ensure birthdate is valid
      if (birthDate.HasValue)
      {
        // compute the different in years
        age = n.Year - birthDate.Value.Year;

        // reduce age value if current month or day precedes the birth date value
        if (n.Month < birthDate.Value.Month || (n.Month == birthDate.Value.Month && n.Day < birthDate.Value.Day))
        {
          age--;
        }
      }

      return age;
    }
  }
}
