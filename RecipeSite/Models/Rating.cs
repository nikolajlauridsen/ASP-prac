using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models{
    public class Rating{
        public int ID{get; set;}

        [Required]
        [Range(1,5)]
        public int Value{get; set;}

        public int RecipeID{get; set;}
    }
}