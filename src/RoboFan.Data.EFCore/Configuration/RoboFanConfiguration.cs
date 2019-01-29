using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Data.EFCore.Configuration
{
  public class RoboFanConfiguration
  {
    public RoboFanConfiguration(EntityTypeBuilder<RoboFanEntity> entity)
    {
      entity.Property(e => e.FirstName).HasMaxLength(64).IsRequired();
      entity.Property(e => e.LastName).HasMaxLength(64).IsRequired();
      entity.Property(e => e.Address).HasMaxLength(128).IsRequired();
      entity.Property(e => e.City).HasMaxLength(64).IsRequired();
      entity.Property(e => e.State).HasMaxLength(64).IsRequired();
    }
  }
}
