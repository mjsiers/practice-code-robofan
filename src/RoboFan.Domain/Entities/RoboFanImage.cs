using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  public class RoboFanImage
  {
    [Key]
    public int Id { get; set; }
    public Guid GuidId { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string ContentType { get; set; }
    public byte[] ImageData { get; set; }

    public int RoboFanId { get; set; }
    //public virtual RoboFan RoboFan { get; set; }
  }
}
