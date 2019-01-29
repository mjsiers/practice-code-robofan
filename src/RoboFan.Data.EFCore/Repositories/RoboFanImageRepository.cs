using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoboFan.Domain.Repositories;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.EFCore.Repositories
{
  public class RoboFanImageRepository : IRobotFanImageRepository
  {
    private readonly RoboFanContext _context;

    public RoboFanImageRepository(RoboFanContext context)
    {
      _context = context;
    }

    public async Task<RoboFanImage> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
    {
      return await _context.RoboFanImage.FindAsync(id);
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
