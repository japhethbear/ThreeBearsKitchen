using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThreeBearsKitchen.Data;
using ThreeBearsKitchen.Models;

namespace ThreeBearsKitchen.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly ThreeBearsKitchen.Data.ThreeBearsKitchenContext _context;

        public EditModel(ThreeBearsKitchen.Data.ThreeBearsKitchenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var existingRecipe =  await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(m => m.RecipeId == id);

            if (existingRecipe == null)
            {
                return NotFound();
            }
            Recipe = existingRecipe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            var existingRecipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(m => m.RecipeId == id);

            if (existingRecipe == null)
            {
                return NotFound();
            }

            existingRecipe.RecipeName = Recipe.RecipeName;
            existingRecipe.RecipeMeal = Recipe.RecipeMeal;

            existingRecipe.Ingredients = Recipe.Ingredients;
            existingRecipe.Instructions = Recipe.Instructions;

            _context.Update(existingRecipe);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id.Value))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
          return (_context.Recipes?.Any(e => e.RecipeId == id)).GetValueOrDefault();
        }
    }
}
