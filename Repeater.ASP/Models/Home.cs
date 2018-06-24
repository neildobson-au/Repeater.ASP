using System.Collections.Generic;

namespace Repeater.ASP.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public int Number { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
