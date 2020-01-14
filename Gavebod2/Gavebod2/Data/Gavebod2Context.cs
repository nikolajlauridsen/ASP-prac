using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gavebod2.Models
{
    public class Gavebod2Context : DbContext
    {
        public Gavebod2Context (DbContextOptions<Gavebod2Context> options)
            : base(options)
        {
        }

        public DbSet<Gavebod2.Models.Gift> Gift { get; set; }
    }
}
