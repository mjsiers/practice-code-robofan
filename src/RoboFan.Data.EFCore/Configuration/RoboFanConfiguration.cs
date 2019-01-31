using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboFanEntity = RoboFan.Domain.Entities.RoboFan;

namespace RoboFan.Data.EFCore.Configuration
{
  public class RoboFanConfiguration
  {
    public RoboFanConfiguration(EntityTypeBuilder<RoboFanEntity> entity)
    {
      // adjust the default property settings
      entity.Property(e => e.FirstName).HasMaxLength(64).IsRequired();
      entity.Property(e => e.LastName).HasMaxLength(64).IsRequired();
      entity.Property(e => e.Address).HasMaxLength(128).IsRequired();
      entity.Property(e => e.City).HasMaxLength(64).IsRequired();
      entity.Property(e => e.State).HasMaxLength(64).IsRequired();
    }
  }
}
