using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.Entities
{
  public class RoboFan
  {
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    [Column("BirthDate", TypeName = "DateTime2")]
    public DateTime? BirthDate { get; set; }

    public virtual RoboFanImage RoboFanImage { get; set; }
    public int? PrimaryTeamId { get; set; }
    public virtual LeagueTeam PrimaryTeam { get; set; }
    public virtual ICollection<RoboFanTeamRanking> FanRankings { get; set; }
  }
}
