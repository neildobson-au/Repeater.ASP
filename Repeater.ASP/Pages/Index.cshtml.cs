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

        public void OnGet()
        {
            AustralianHomes = new AustralianHomesViewModel
            {
                States = new List<State>
                {
                    new State {Name = "ACT", IsTerritory = true},
                    new State {Name = "NSW"},
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
