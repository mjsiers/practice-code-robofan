using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
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
      const int imgwidth = 100;
      const int imgheight = 100;
      List<RoboFanEntity> listitems = new List<RoboFanEntity>();

      // generate random values for the majority of the fan properties
      DateTime mindate = DateTime.Now.AddYears(-5);
      var faker = new Faker<RoboFanEntity>()
          .RuleFor(o => o.GuidId, f => f.Random.Guid())
          .RuleFor(o => o.FirstName, f => f.Name.FirstName())
          .RuleFor(o => o.LastName, f => f.Name.LastName())
          .RuleFor(o => o.Address, f => f.Address.StreetAddress())
          .RuleFor(o => o.City, f => f.Address.City())
          .RuleFor(o => o.State, f => f.Address.StateAbbr())
          .RuleFor(o => o.BirthDate, f => f.Date.Past(50, mindate))
          .RuleFor(o => o.PrimaryTeamId, f => f.Random.Int(1, maxteamid));
      listitems = faker.Generate(num);

      // create web client to download robot images with
      using (var client = new WebClient())
      {
        // loop through all the generated items
        foreach (var fan in listitems)
        {
          // generate a random robot image using the robohash website and download the image data
          var imageurl = string.Format("https://robohash.org/robots/{0}?size={1}x{2}", fan.GuidId, imgwidth, imgheight);
          fan.Image = client.DownloadData(imageurl);
        }
      }

      return listitems;
    }
  }
}
