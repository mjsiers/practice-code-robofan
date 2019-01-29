using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  public class LeagueTeam
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    public string ImageUrl { get; set; }

    public virtual ICollection<RoboFan> RobotFans { get; set; }
    public virtual ICollection<RoboFanTeamRanking> FanRankings { get; set; }

    public LeagueTeam()
    {
    }

    public LeagueTeam(int id, string name, string conference, string imageurl)
    {
      this.Id = id;
      this.Name = name;
      this.Conference = conference;
      this.ImageUrl = imageurl;
    }
  }
}
