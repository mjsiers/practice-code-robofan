using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Domain.Repositories
{
  public interface IRoboFanRepository : IDisposable
  {
    Task<List<RoboFanEntity>> GetAllAsync(CancellationToken ct = default(CancellationToken));
    Task<List<RoboFanEntity>> GetAllFilterAsync(string namefilter, CancellationToken ct = default(CancellationToken));
    Task<RoboFanEntity> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
    Task<RoboFanEntity> AddAsync(RoboFanEntity newFan, CancellationToken ct = default(CancellationToken));
    Task<bool> AddManyAsync(List<RoboFanEntity> listfans, CancellationToken ct = default(CancellationToken));
    Task<bool> UpdateAsync(RoboFanEntity fan, CancellationToken ct = default(CancellationToken));
    Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
  }
}
