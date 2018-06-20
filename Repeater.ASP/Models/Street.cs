using System.Collections.Generic;

namespace Repeater.ASP.Models
{
    public class Street
    {
        public string Name { get; set; }
        public List<Home> Homes { get; set; } = new List<Home>();
    }
}
