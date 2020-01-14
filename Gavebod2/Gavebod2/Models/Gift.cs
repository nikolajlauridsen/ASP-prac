using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gavebod2.Models
{
    public class Gift
    {
        [Key]
        public int GiftNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "String must be between 3 and 100 characters long")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "String must be between 3 and 100 characters long")]
        public string Description { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Boy gift")]
        public bool BoyGift { get; set; }

        [Required]
        [Display(Name = "Girl gift")]
        public bool GirlGift { get; set; }
    }

}
