using Microsoft.EntityFrameworkCore;
using TestHarness.Models;

namespace TestHarness.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Business> Businesses { get; set; }
    }
}
