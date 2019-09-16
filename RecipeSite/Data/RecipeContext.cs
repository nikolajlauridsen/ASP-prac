using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeSite.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext (DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Comment> Comments{get; set;}
        public DbSet<Rating> Ratings{get; set;}
        public DbSet<Ingredient> Ingredients{get; set;}
        public DbSet<Unit> Units{get; set;}
    }
}
