using Microsoft.EntityFrameworkCore;

namespace TP.Models
{
    public class AppDbContext : DbContext
    {   
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gastos> Gastos { get; set; }
    }
}
