using Fiorella.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products    { get; set; }
    }
}
