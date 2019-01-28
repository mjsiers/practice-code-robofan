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
    public Guid GuidId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    [Column("BirthDate", TypeName = "DateTime2")]
    public DateTime? BirthDate { get; set; }
    public byte[] Image { get; set; }

    [ForeignKey("PrimaryTeamId")]
    public LeagueTeam PrimaryTeam { get; set; }
    public ICollection<RoboFanTeamRanking> FanRankings { get; set; }
  }
}
