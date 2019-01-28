using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  public class RoboFanTeamRanking
  {
    public int RobotFanId { get; set; }
    public global::RoboFan.Domain.Entities.RoboFan RobotFan { get; set; }
    public int LeagueTeamId { get; set; }
    public LeagueTeam LeagueTeam { get; set; }
    public int Ranking { get; set; }
  }
}
