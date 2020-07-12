using CH11_Transactions.Models;
using Microsoft.EntityFrameworkCore;

namespace CH11_Transactions.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Business> Businesses { get; set; }
    }
}
