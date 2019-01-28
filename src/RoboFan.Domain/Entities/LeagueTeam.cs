using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  // https://www.learnentityframeworkcore.com/

  public class LeagueTeam
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<RoboFan> RobotFans { get; set; }
    public ICollection<RoboFanTeamRanking> FanRankings { get; set; }
  }
}
