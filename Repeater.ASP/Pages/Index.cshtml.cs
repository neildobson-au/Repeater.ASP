using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repeater.ASP.Models;

namespace Repeater.ASP.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AustralianHomesViewModel AustralianHomes { get; set; }

        #region Templates

        public State EmptyState { get; set; } = new State();
        public Location EmptyLocation { get; set; } = new Location();
        public Street EmptyStreet { get; set; } = new Street();
        public Home EmptyHome { get; set; } = new Home();
        public Room EmptyRoom { get; set; } = new Room();

        #endregion

        public void OnGet()
        {
            AustralianHomes = new AustralianHomesViewModel
            {
                States = new List<State>
                {
                    new State
                    {
                        Name = "ACT", 
                        IsTerritory = true
                    },
                    new State
                    {
                        Name = "NSW",
                        Locations = new List<Location>
                        {
                            new Location { PostCode = 2000, Suburb = "Sydney" },
                            new Location
                            {
                                PostCode = 2065, 
                                Suburb = "Wollstonecraft",
                                Streets = new List<Street>
                                {
                                    new Street
                                    {
                                        Name = "Nicholson St",
                                        Homes = new List<Home>
                                        {
                                            new Home 
                                            { 
                                                Number = 1, 
                                                Rooms = new List<Room>
                                                {
                                                    new Room { Name = "Lounge", Length = 650, Width = 450 },
                                                    new Room { Name = "Kitchen", Length = 280, Width = 330 },
                                                    new Room { Name = "Bedroom", Length = 400, Width = 250 }
                                                }
                                            },
                                            new Home 
                                            { 
                                                Number = 2, 
                                                Rooms = new List<Room>
                                                {
                                                    new Room { Name = "Lounge", Length = 550, Width = 630 },
                                                    new Room { Name = "Kitchen", Length = 300, Width = 340 },
                                                    new Room { Name = "Bedroom 1", Length = 420, Width = 275 },
                                                    new Room { Name = "Bedroom 2", Length = 420, Width = 245 }
                                                }
                                            }
                                        }
                                    },
                                    new Street { Name = "Belmont St" }
                                }
                            }
                        }
                    },
                    new State {Name = "NT", IsTerritory = true},
                    new State {Name = "QLD"},
                    new State {Name = "SA"},
                    new State {Name = "TAS"},
                    new State {Name = "VIC"},
                    new State {Name = "WA"},
                }
            };
        }
    }
}
