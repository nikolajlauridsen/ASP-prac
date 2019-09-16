using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSite.Models;

namespace RecipeSite.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeSite.Models.RecipeContext _context;

        public IndexModel(RecipeSite.Models.RecipeContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe.Include(r=> r.Ratings).ToListAsync();
        }
    }
}
