using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  // https://www.learnentityframeworkcore.com/

  public class LeagueTeam
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<RobotFan> RobotFans { get; set; }
    public ICollection<RobotFanTeamRanking> FanRankings { get; set; }
  }
}
