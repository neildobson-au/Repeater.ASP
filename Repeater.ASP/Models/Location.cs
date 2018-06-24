using System.Collections.Generic;

namespace Repeater.ASP.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
        public List<Street> Streets { get; set; } = new List<Street>();
    }
}
