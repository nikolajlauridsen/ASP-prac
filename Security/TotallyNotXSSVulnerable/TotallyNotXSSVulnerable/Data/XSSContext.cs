using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TotallyNotXSSVulnerable.Models
{
    public class XSSContext : DbContext
    {
        public XSSContext (DbContextOptions<XSSContext> options)
            : base(options)
        {
        }

        public DbSet<TotallyNotXSSVulnerable.Models.Comment> Comment { get; set; }
    }
}
