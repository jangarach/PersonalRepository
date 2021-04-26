using HomeRenovationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator
{
    public class AppContext : DbContext
    {
        public AppContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Glue> Glue { get; set; }
        public DbSet<Plaster> Plaster { get; set; }
        public DbSet<WallPaint> Wall { get; set; }
        public DbSet<Putty> Putty { get; set; }
        public DbSet<WallPaper> WallPaper { get; set; }
    }
}
