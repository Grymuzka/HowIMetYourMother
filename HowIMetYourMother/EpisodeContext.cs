using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowIMetYourMother
{
    public class EpisodeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-CJHIAF2A\SQLEXPRESS; database=Himym; trusted_connection=true");
        }

        public DbSet<Episode> Episodes { get; set; }
    }
}
