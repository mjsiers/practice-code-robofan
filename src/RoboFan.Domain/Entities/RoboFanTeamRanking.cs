using System;
using System.Collections.Generic;
using System.Text;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Domain.Entities
{
  public class RoboFanTeamRanking
  {
    public int RobotFanId { get; set; }
    public int LeagueTeamId { get; set; }
    public virtual LeagueTeam LeagueTeam { get; set; }
    public int Ranking { get; set; }
  }
}
