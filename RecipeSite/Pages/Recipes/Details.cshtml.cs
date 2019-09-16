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
    public class DetailsModel : PageModel
    {
        private readonly RecipeSite.Models.RecipeContext _context;

        public DetailsModel(RecipeSite.Models.RecipeContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe.Include(r=>r.Comments).Include(i=>i.Ingredients).ThenInclude(u=>u.Unit).FirstOrDefaultAsync(m => m.ID == id);
            
            

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
