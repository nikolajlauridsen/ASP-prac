using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lufthavn.Models
{
    public class LufthavnContext : DbContext
    {
        public LufthavnContext (DbContextOptions<LufthavnContext> options)
            : base(options)
        {
        }

        public DbSet<Lufthavn.Models.Flight> Flight { get; set; }
    }
}
