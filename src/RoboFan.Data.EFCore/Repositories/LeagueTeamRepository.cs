using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Repositories;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.EFCore.Repositories
{
  public class LeagueTeamRepository : ILeagueTeamRepository
  {
    private readonly RoboFanContext _context;

    public LeagueTeamRepository(RoboFanContext context)
    {
      _context = context;
    }

    public async Task<List<LeagueTeam>> GetAllAsync(CancellationToken ct = default)
    {
      return await _context.LeagueTeam.ToListAsync(ct);
    }

    public async Task<LeagueTeam> GetByIdAsync(int id, CancellationToken ct = default)
    {
      return await _context.LeagueTeam.FindAsync(id);
    }

    public async Task<LeagueTeam> AddAsync(LeagueTeam newTeam, CancellationToken ct = default)
    {
      _context.LeagueTeam.Add(newTeam);
      await _context.SaveChangesAsync(ct);
      return newTeam;
    }

    public async Task<bool> UpdateAsync(LeagueTeam team, CancellationToken ct = default)
    {
      if (!await LeagueTeamExists(team.Id, ct))
        return false;
      _context.LeagueTeam.Update(team);
      await _context.SaveChangesAsync(ct);
      return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
      if (!await LeagueTeamExists(id, ct))
        return false;
      var toRemove = _context.LeagueTeam.Find(id);
      _context.LeagueTeam.Remove(toRemove);
      await _context.SaveChangesAsync(ct);
      return true;
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    private async Task<bool> LeagueTeamExists(int id, CancellationToken ct = default)
    {
      return await GetByIdAsync(id, ct) != null;
    }
  }
}
