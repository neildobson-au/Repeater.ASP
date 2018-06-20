using System.Collections.Generic;

namespace Repeater.ASP.Models
{
    public class State
    {
        public string Name { get; set; }
        public bool IsTerritory { get; set; }
        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
