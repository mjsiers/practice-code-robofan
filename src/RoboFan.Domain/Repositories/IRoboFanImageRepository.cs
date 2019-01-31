using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RoboFan.Domain.Entities;

namespace RoboFan.Domain.Repositories
{
  public interface IRoboFanImageRepository : IDisposable
  {
    Task<RoboFanImage> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
  }
}
