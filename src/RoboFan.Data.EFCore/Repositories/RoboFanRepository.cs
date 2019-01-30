using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Repositories;
using RoboFan.Domain.Entities;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Data.EFCore.Repositories
{
  public class RoboFanRepository : IRoboFanRepository
  {
    private readonly RoboFanContext _context;

    public RoboFanRepository(RoboFanContext context)
    {
      _context = context;
    }

    public async Task<List<RoboFanEntity>> GetAllAsync(CancellationToken ct = default(CancellationToken))
    {
      return await _context.RoboFan.ToListAsync(ct);
    }

    public async Task<RoboFanEntity> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
    {
      // build up query to also load the child objects
      var query = (from robofan in _context.RoboFan
                   .Include("RoboFanImage").Include("PrimaryTeam").Include("FanRankings").Include("FanRankings.LeagueTeam")
                   where robofan.Id == id
                   select robofan).SingleOrDefaultAsync<RoboFanEntity>();
      return await query;
    }

    public async Task<RoboFanEntity> AddAsync(RoboFanEntity newFan, CancellationToken ct = default(CancellationToken))
    {
      _context.RoboFan.Add(newFan);
      await _context.SaveChangesAsync(ct);
      return newFan;
    }

    public async Task<bool> UpdateAsync(RoboFanEntity fan, CancellationToken ct = default(CancellationToken))
    {
      if (!await RoboFanExists(fan.Id, ct))
        return false;
      _context.RoboFan.Update(fan);
      await _context.SaveChangesAsync(ct);
      return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
    {
      if (!await RoboFanExists(id, ct))
        return false;
      var toRemove = _context.RoboFan.Find(id);
      _context.RoboFan.Remove(toRemove);
      await _context.SaveChangesAsync(ct);
      return true;
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    private async Task<bool> RoboFanExists(int id, CancellationToken ct = default(CancellationToken))
    {
      return await GetByIdAsync(id, ct) != null;
    }
  }
}
