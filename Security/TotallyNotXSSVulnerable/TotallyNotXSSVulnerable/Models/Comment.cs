using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyNotXSSVulnerable.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
    }
}
