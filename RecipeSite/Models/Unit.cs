using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSite.Models{
    public class Unit{
        public int ID{get; set;}

        [Required]
        public string Name{get; set;}
    }
}