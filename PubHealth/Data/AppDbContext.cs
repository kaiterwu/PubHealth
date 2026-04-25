using Microsoft.EntityFrameworkCore;
using PubHealth.Models;

namespace PubHealth.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Slide> Slides => Set<Slide>();
    }
}
