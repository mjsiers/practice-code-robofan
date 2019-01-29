using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboFan.Domain.Entities;

namespace RoboFan.Data.EFCore.Configuration
{
  public class RoboFanImageConfiguration
  {
    public RoboFanImageConfiguration(EntityTypeBuilder<RoboFanImage> entity)
    {
      entity.Property(e => e.ContentType).HasMaxLength(64).IsRequired();
    }
  }
}
