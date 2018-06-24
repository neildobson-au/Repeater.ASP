using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repeater.ASP.Data;
using Repeater.ASP.Models;

namespace Repeater.ASP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<State> repository;

        public IndexModel(IRepository<State> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public AustralianHomes AustralianHomes { get; set; }

        #region Templates

        public State EmptyState { get; set; } = new State();
        public Location EmptyLocation { get; set; } = new Location();
        public Street EmptyStreet { get; set; } = new Street();
        public Home EmptyHome { get; set; } = new Home();
        public Room EmptyRoom { get; set; } = new Room();

        #endregion

        public void OnGet()
        {
            AustralianHomes = new AustralianHomes
            {
                States = repository.GetAll().ToList()
            };
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var state in AustralianHomes.States)
            {
                repository.Update(state);
            }

            return RedirectToPage();
        }
    }
}
