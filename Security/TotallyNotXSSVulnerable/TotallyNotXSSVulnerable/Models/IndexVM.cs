using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TotallyNotXSSVulnerable.Models
{
    public class IndexVM
    {
        public List<Comment> Comments { get; set; }

        [Display(Name = "Write comment")]
        public string CommentContent { get; set; }
    }
}
