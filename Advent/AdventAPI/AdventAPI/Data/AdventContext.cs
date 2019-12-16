using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventAPI.Model;

namespace AdventAPI.Models
{
    public class AdventContext : DbContext
    {
        public AdventContext (DbContextOptions<AdventContext> options)
            : base(options)
        {
        }

        public DbSet<AdventAPI.Model.AdventFact> AdventFact { get; set; }
    }
}
