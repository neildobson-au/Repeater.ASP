using System.Collections.Generic;

namespace Repeater.ASP.Models
{
    public class Street
    {
        public int StreetId { get; set; }
        public string Name { get; set; }
        public List<Home> Homes { get; set; } = new List<Home>();
    }
}
