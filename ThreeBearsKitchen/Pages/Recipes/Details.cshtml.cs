using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThreeBearsKitchen.Data;
using ThreeBearsKitchen.Models;

namespace ThreeBearsKitchen.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly ThreeBearsKitchen.Data.ThreeBearsKitchenContext _context;

        public DetailsModel(ThreeBearsKitchen.Data.ThreeBearsKitchenContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = recipe;
            }
            return Page();
        }
    }
}
