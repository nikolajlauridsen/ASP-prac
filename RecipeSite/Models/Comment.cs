using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSite.Models{
    public class Comment{
        public int ID{get; set;}

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Published{get; set;}

        [Required]
        [MaxLength(500)]
        public string CommentText{get; set;}

        public int RecipeID{get; set;}
    }
}