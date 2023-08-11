using bayi_harita.Models;
using Microsoft.EntityFrameworkCore;

namespace bayi_harita
{
    public class bayiDbContext : DbContext
    {
        public bayiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bayi> Bayiler { get; set; }
  
    }
}
