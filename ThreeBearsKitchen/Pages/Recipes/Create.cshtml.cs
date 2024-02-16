using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThreeBearsKitchen.Data;
using ThreeBearsKitchen.Models;

namespace ThreeBearsKitchen.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly ThreeBearsKitchen.Data.ThreeBearsKitchenContext _context;

        public CreateModel(ThreeBearsKitchen.Data.ThreeBearsKitchenContext context)
        {
            _context = context;
        }

        // Property Binding

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        // On Get

        public void OnGet()
        {
            Recipe = new Recipe();
        }


        // On Post Async

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
