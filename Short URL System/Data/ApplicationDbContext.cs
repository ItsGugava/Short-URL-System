using Microsoft.EntityFrameworkCore;
using Short_URL_System.Models;

namespace Short_URL_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Website> Websites { get; set; }
    }
}
