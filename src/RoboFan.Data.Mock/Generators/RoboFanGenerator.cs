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
    public static List<RoboFanEntity> Generate(int num = 1)
    {
      const int maxteamid = 24;
      List<RoboFanEntity> listitems = new List<RoboFanEntity>();

      // generate random values for the majority of the fan properties
      DateTime mindate = DateTime.Now.AddYears(-5);
      var faker = new Faker<RoboFanEntity>()
          .RuleFor(o => o.FirstName, f => f.Name.FirstName())
          .RuleFor(o => o.LastName, f => f.Name.LastName())
          .RuleFor(o => o.Address, f => f.Address.StreetAddress())
          .RuleFor(o => o.City, f => f.Address.City())
          .RuleFor(o => o.State, f => f.Address.StateAbbr())
          .RuleFor(o => o.BirthDate, f => f.Date.Past(50, mindate))
          .RuleFor(o => o.PrimaryTeamId, f => f.Random.Int(1, maxteamid));
      listitems = faker.Generate(num);

      // loop through all the generated items
      var fanid = 1;
      foreach (var fan in listitems)
      {
        // update the fanid and generate a robot image for the fan
        fan.Id = fanid;
        fan.RoboFanImage = RoboFanImageGenerator.Generate(fan.Id);
        fanid++;
      }

      return listitems;
    }
  }
}
