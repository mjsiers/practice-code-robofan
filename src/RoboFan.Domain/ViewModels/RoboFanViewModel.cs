using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFan.Domain.ViewModels
{
  public class RoboFanViewModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string BirthDate { get; set; }
    public int Age { get; set; }
    public string ImageUrl { get; set; }
    public string TeamName { get; set; }
    public string TeamImageUrl { get; set; }
    public List<string> PosTeams { get; set; }
    public List<string> NegTeams { get; set; }
  }
}
