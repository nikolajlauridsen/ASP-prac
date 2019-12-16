using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdventAPI.Model
{
    public class AdventFact
    {
        public int id { get; set; }
        
        [Range(1, 25)]
        public int Day { get; set; }

        public string Fact { get; set; }

    }
}
