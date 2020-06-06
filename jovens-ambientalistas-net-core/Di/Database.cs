using jovens_ambientalistas_net_core.Entity;
using Microsoft.EntityFrameworkCore;

namespace jovens_ambientalistas_net_core.Di
{
    public class Database: DbContext
    {
        public DbSet<Product> Product { get; set; }

        public Database(DbContextOptions options): base(options) { }
    }
}