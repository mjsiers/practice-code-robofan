using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.EFCore.Configuration
{
  public class RoboFanImageConfiguration
  {
    public RoboFanImageConfiguration(EntityTypeBuilder<RoboFanImage> entity)
    {
      // adjust the default property settings
      entity.Property(e => e.ContentType).HasMaxLength(64).IsRequired();
    }
  }
}
