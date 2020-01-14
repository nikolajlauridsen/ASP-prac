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
        public string Title { get; set; }

        [Required]
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
