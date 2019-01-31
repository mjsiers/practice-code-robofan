﻿using System.Linq;
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
      // build up query to also load the child objects
      var query = (from robofan in _context.RoboFan
                   .Include("RoboFanImage").Include("PrimaryTeam").Include("FanRankings").Include("FanRankings.LeagueTeam")
                   select robofan).ToListAsync(ct);
      return await query;
    }

    public async Task<List<RoboFanEntity>> GetAllFilterAsync(string namefilter, CancellationToken ct = default(CancellationToken))
    {
      // first query for all the records
      var query = (from robofan in _context.RoboFan
                   .Include("RoboFanImage").Include("PrimaryTeam").Include("FanRankings").Include("FanRankings.LeagueTeam")
                   select robofan);
      if (!string.IsNullOrEmpty(namefilter))
      {
        // add in the specified name filter value
        query = query.Where(s => s.FirstName.Contains(namefilter, System.StringComparison.OrdinalIgnoreCase) ||
                                 s.LastName.Contains(namefilter, System.StringComparison.OrdinalIgnoreCase));
      }

      return await query.ToListAsync(ct);
    }

    public async Task<RoboFanEntity> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
    {
      // build up query to also load the child objects
      var query = (from robofan in _context.RoboFan
                   .Include("RoboFanImage").Include("PrimaryTeam").Include("FanRankings").Include("FanRankings.LeagueTeam")
                   where robofan.Id == id
                   select robofan).SingleOrDefaultAsync<RoboFanEntity>(ct);
      return await query;
    }

    public async Task<RoboFanEntity> AddAsync(RoboFanEntity newFan, CancellationToken ct = default(CancellationToken))
    {
      _context.RoboFan.Add(newFan);
      await _context.SaveChangesAsync(ct);
      return newFan;
    }

    public async Task<bool> AddManyAsync(List<RoboFanEntity> listfans, CancellationToken ct = default(CancellationToken))
    {
      // loop over all the generated fans
      foreach (var fan in listfans)
      {
        // save off the fan ranking values since we cannot add them until we know the record id
        // also clear out the primary team since the record already exists in db
        var fanimage = fan.RoboFanImage;
        var fanrankings = fan.FanRankings;
        fan.RoboFanImage = null;
        fan.FanRankings = null;
        fan.PrimaryTeam = null;

        // add the fan and image records to the database
        fan.Id = 0;
        _context.RoboFan.Add(fan);
        await _context.SaveChangesAsync(ct);

        // update the fan id value and add in the image record
        fanimage.Id = 0;
        fanimage.RoboFanId = fan.Id;
        _context.RoboFanImage.Add(fanimage);
        await _context.SaveChangesAsync(ct);

        // loop over all the rankings
        foreach (var ranking in fanrankings)
        {
          // ensure the objects are null and ids are correct
          ranking.LeagueTeam = null;
          ranking.RobotFanId = fan.Id;

          // save the ranking record
          _context.RoboFanTeamRanking.Add(ranking);
        }
        await _context.SaveChangesAsync(ct);
      }

      return true;
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
