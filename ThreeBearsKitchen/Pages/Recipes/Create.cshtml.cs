using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        [BindProperty]
        public Ingredient NewIngredient { get; set; } = new Ingredient();

        [BindProperty]
        public Instruction NewInstruction { get; set; } = new Instruction();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Running OnPostAsync...");
          if (_context.Recipes == null || Recipe == null)
            {

                Console.WriteLine("ModelState invalid or Recipe null"); // Add this line

                return Page();
            }

            Recipe.UserId = "345";

            Recipe.Ingredients = new List<Ingredient> { NewIngredient };

            Recipe.Instructions = new List<Instruction> { NewInstruction };

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            Console.WriteLine("OnPostAsync end"); // Add this line

            return RedirectToPage("./Index");
        }
    }
}
