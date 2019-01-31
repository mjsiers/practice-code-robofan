using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;

namespace RoboFan.Domain.Repositories
{
  public interface ILeagueTeamRepository : IDisposable
  {
    Task<List<LeagueTeam>> GetAllAsync(CancellationToken ct = default);
    Task<LeagueTeam> GetByIdAsync(int id, CancellationToken ct = default);
    Task<LeagueTeam> AddAsync(LeagueTeam newTeam, CancellationToken ct = default);
    Task<bool> UpdateAsync(LeagueTeam team, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
  }
}
