using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RecipeSite.Models{
    public class SeedData{
        public static void Initialize(RecipeContext context){
            
            if (context.Recipe.Any())
            {
                return;   // DB has been seeded
            }

            var recipes = new Recipe[]{
                new Recipe{Title = "Spejlæg", Procedure="Steg lortet",
                           Author = "Nikolaj", Published = DateTime.Now}
            };
            foreach(Recipe rec in recipes){
                context.Recipe.Add(rec);
            }
            context.SaveChanges();

            var units = new Unit[]{
                new Unit{Name = "Gr"},
                new Unit{Name = "Stk"},
                new Unit{Name = "Ml"},
                new Unit{Name = "L"}
            };

            foreach(Unit un in units){
                context.Units.Add(un);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]{
                new Ingredient{ Name = "Æg", Quantity = 3, 
                UnitID = units.Single(i => i.Name == "Stk").ID,
                RecipeID = recipes.Single(i => i.Title == "Spejlæg").ID
                }
            };
            foreach(Ingredient ing in ingredients){
                context.Ingredients.Add(ing);
            }
            context.SaveChanges();

            var comments = new Comment[]{
                new Comment{Published=DateTime.Now, CommentText="Verdens bedste opskrift", RecipeID = recipes.Single(i=>i.Title == "Spejlæg").ID},
                new Comment{Published=DateTime.Now, CommentText="Hader den her opskrift", RecipeID = recipes.Single(i=>i.Title == "Spejlæg").ID}
            };

            foreach(Comment comment in comments){
                context.Comments.Add(comment);
            }
            context.SaveChanges();

            var ratings = new Rating[]{
                new Rating{Value=5, RecipeID = recipes.Single(r=> r.Title == "Spejlæg").ID},
                new Rating{Value=1, RecipeID = recipes.Single(r=> r.Title == "Spejlæg").ID},  
            };
            foreach(Rating rating in ratings){
                context.Ratings.Add(rating);
            }
            context.SaveChanges();


            
        }
    }
}