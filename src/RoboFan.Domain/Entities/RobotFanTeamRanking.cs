using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  public class RobotFanTeamRanking
  {
    public int RobotFanId { get; set; }
    public RoboFan.Domain.Entities.RobotFan RobotFan { get; set; }
    public int LeagueTeamId { get; set; }
    public LeagueTeam LeagueTeam { get; set; }
    public int Ranking { get; set; }
  }
}
