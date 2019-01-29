using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;
using Bogus;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanGenerator
  {
    public static List<RoboFanEntity> Generate(int num = 1, bool generateImage = true, bool generateRankings = true)
    {
      // generate list of teams and single robo fan
      Random randNum = new Random();
      List<RoboFanEntity> listitems = new List<RoboFanEntity>();
      var listteams = LeagueTeamGenerator.Generate();

      // generate random values for the majority of the fan properties
      DateTime mindate = DateTime.Now.AddYears(-5);
      var faker = new Faker<RoboFanEntity>()
          .RuleFor(o => o.FirstName, f => f.Name.FirstName())
          .RuleFor(o => o.LastName, f => f.Name.LastName())
          .RuleFor(o => o.Address, f => f.Address.StreetAddress())
          .RuleFor(o => o.City, f => f.Address.City())
          .RuleFor(o => o.State, f => f.Address.StateAbbr())
          .RuleFor(o => o.BirthDate, f => f.Date.Past(50, mindate));
      listitems = faker.Generate(num);

      // loop through all the generated items
      var fanid = 1;
      foreach (var fan in listitems)
      {
        // update fan id value and generate a primary team for the fan
        var teampos = randNum.Next(listteams.Count - 1);
        fan.Id = fanid;
        fan.PrimaryTeamId = listteams[teampos].Id;
        fan.PrimaryTeam = listteams[teampos];

        // update the fanid and generate child entities if specified
        fan.RoboFanImage = RoboFanImageGenerator.Generate(fan.Id, generateImage);
        if (generateRankings)
        {
          fan.FanRankings = RoboFanTeamRankingsGenerator.GenerateTeamRankings(fan, listteams);
        }

        // increment the fan id value
        fanid++;
      }

      return listitems;
    }
  }
}
