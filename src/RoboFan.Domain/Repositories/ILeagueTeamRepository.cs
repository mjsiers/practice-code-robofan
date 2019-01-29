using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;

namespace RoboFan.Domain.Repositories
{
  public interface ILeagueTeamRepository
  {
    Task<List<LeagueTeam>> GetAllAsync(CancellationToken ct = default(CancellationToken));
    Task<LeagueTeam> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
    Task<LeagueTeam> AddAsync(LeagueTeam newTeam, CancellationToken ct = default(CancellationToken));
    Task<bool> UpdateAsync(LeagueTeam team, CancellationToken ct = default(CancellationToken));
    Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
  }
}
