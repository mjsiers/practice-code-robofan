using System;
using System.Collections.Generic;
using System.Linq;
using RoboFan.Domain.Entities;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Data.Mock.Generators
{
  public static class RoboFanTeamRankingsGenerator
  {
    public static List<RoboFanTeamRanking> GenerateTeamRankings(RoboFanEntity robofan, List<LeagueTeam> leagueTeams)
    {
      const int maxposteams = 3;
      const int maxnegteams = 5;
      List<RoboFanTeamRanking> listRankings = new List<RoboFanTeamRanking>();

      // get a list of available team ids to use for fan rankings
      var teams = (from team in leagueTeams
                   where (team.Id != robofan.PrimaryTeamId)
                   select team.Id).ToList<int>();

      // select the positive and negative teams for this fan
      SelectRandomTeams(maxposteams, robofan.Id, 1, ref teams, ref listRankings);
      SelectRandomTeams(maxnegteams, robofan.Id, -1, ref teams, ref listRankings);

      return listRankings;
    }

    private static void SelectRandomTeams(int numteams, int fanid, int teamranking, ref List<int> teamids, ref List<RoboFanTeamRanking> listRankings)
    {
      // select the number of requested teams
      Random randNum = new Random();
      for (int index = 0; index < numteams; index++)
      {
        // create a new object to save the results int
        var ranking = new RoboFanTeamRanking();
        ranking.RobotFanId = fanid;
        ranking.Ranking = teamranking;

        // select a random index from the remaining teams and save in the object
        var teampos = randNum.Next(teamids.Count - 1);
        ranking.LeagueTeamId = teamids[teampos];
        teamids.RemoveAt(teampos);

        // add the object to the return list
        listRankings.Add(ranking);
      }
    }
  }
}
