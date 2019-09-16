using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSite.Models{
    public class Recipe{
        public int ID{get; set;}

        [Required]
        [MaxLength(100)]
        public string Title{get; set;}

        [Required]
        public string Procedure{get; set;}

        [Required]
        [MaxLength(50)]
        public string Author{get; set;}

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Published{get; set;}
        public ICollection<Ingredient> Ingredients{get; set;}
        public ICollection<Comment> Comments{get; set;}
        public ICollection<Rating> Ratings{get; set;}

        [Display(Name = "Average rating")]
        public double AvgRating{
            get{
                if(Comments == null){
                    return 0;
                }
                int ratingTotal = 0;
                foreach(Rating rating in Ratings){
                    ratingTotal += rating.Value;
                }
                if(Ratings.Count > 0){
                    return ratingTotal/Ratings.Count;
                } else {
                    return 0;
                }
                
        }}
    }
}