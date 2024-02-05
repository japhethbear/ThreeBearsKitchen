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
    public class IndexModel : PageModel
    {
        private readonly ThreeBearsKitchen.Data.ThreeBearsKitchenContext _context;

        public IndexModel(ThreeBearsKitchen.Data.ThreeBearsKitchenContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recipes != null)
            {
                Recipe = await _context.Recipes.ToListAsync();
            }
        }
    }
}
