using System.ComponentModel.DataAnnotations;

namespace RoboFan.Domain.Entities
{
  public class LeagueTeam
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    public string ImageUrl { get; set; }

    public LeagueTeam()
    {
    }

    public LeagueTeam(int id, string name, string conference, string imageurl)
    {
      // constructor that will initialize all the values
      this.Id = id;
      this.Name = name;
      this.Conference = conference;
      this.ImageUrl = imageurl;
    }
  }
}
