using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSite.Models{
    public class Ingredient{
        public int ID{get; set;}

        [Required]
        public string Name{get; set;}

        [Required]
        public double Quantity{get; set;}

        public int UnitID{get; set;}
        public Unit Unit{get; set;}

        public int RecipeID{get; set;}
    }
}