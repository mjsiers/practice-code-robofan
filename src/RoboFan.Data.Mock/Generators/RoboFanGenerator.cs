using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;
using Bogus;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanGenerator
  {
    public static async Task<List<RoboFanEntity>> GenerateAsync(int num, string imagepath, bool generateRankings = true)
    {
      // generate teams and fans
      var listteams = LeagueTeamGenerator.Generate();
      List<RoboFanEntity> listitems = GenerateFans(num, listteams);

      // loop through all the generated items
      foreach (var fan in listitems)
      {
        // update the fanid and generate child entities if specified
        fan.RoboFanImage = await RoboFanImageGenerator.GenerateAsync(fan.Id, imagepath);
        if (generateRankings)
        {
          fan.FanRankings = RoboFanTeamRankingsGenerator.GenerateTeamRankings(fan, listteams);
        }
      }

      return listitems;
    }

    public static List<RoboFanEntity> Generate(int num, string imagepath, bool generateRankings = true)
    {
      // generate teams and fans
      var listteams = LeagueTeamGenerator.Generate();
      List<RoboFanEntity> listitems = GenerateFans(num, listteams);

      // loop through all the generated items
      foreach (var fan in listitems)
      {
        // update the fanid and generate child entities if specified
        fan.RoboFanImage = RoboFanImageGenerator.Generate(fan.Id, imagepath);
        if (generateRankings)
        {
          fan.FanRankings = RoboFanTeamRankingsGenerator.GenerateTeamRankings(fan, listteams);
        }
      }

      return listitems;
    }

    public static async Task<List<RoboFanEntity>> GenerateAsync(int num = 1, bool generateImage = true, bool generateRankings = true)
    {
      // generate teams and fans
      var listteams = LeagueTeamGenerator.Generate();
      List<RoboFanEntity> listitems = GenerateFans(num, listteams);

      // loop through all the generated items
      foreach (var fan in listitems)
      {
        // update the fanid and generate child entities if specified
        fan.RoboFanImage = await RoboFanImageGenerator.GenerateAsync(fan.Id, generateImage);
        if (generateRankings)
        {
          fan.FanRankings = RoboFanTeamRankingsGenerator.GenerateTeamRankings(fan, listteams);
        }
      }

      return listitems;
    }

    public static List<RoboFanEntity> Generate(int num = 1, bool generateImage = true, bool generateRankings = true)
    {
      // generate teams and fans
      var listteams = LeagueTeamGenerator.Generate();
      List<RoboFanEntity> listitems = GenerateFans(num, listteams);

      // loop through all the generated items
      foreach (var fan in listitems)
      {
        // update the fanid and generate child entities if specified
        fan.RoboFanImage = RoboFanImageGenerator.Generate(fan.Id, generateImage);
        if (generateRankings)
        {
          fan.FanRankings = RoboFanTeamRankingsGenerator.GenerateTeamRankings(fan, listteams);
        }
      }

      return listitems;
    }

    private static List<RoboFanEntity> GenerateFans(int num, List<LeagueTeam> listteams)
    {
      Random randNum = new Random();
      List<RoboFanEntity> listitems = new List<RoboFanEntity>();

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

      // loop through all the generated fans
      var fanid = 1;
      foreach (var fan in listitems)
      {
        // update fan id value and generate a primary team for the fan
        var teampos = randNum.Next(listteams.Count - 1);
        fan.Id = fanid;
        fan.PrimaryTeamId = listteams[teampos].Id;
        fan.PrimaryTeam = listteams[teampos];

        // increment the fan id value
        fanid++;
      }

      return listitems;
    }
  }
}
