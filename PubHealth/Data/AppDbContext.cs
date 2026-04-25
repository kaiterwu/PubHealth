using Microsoft.EntityFrameworkCore;
using PubHealth.Models;

namespace PubHealth.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Slide> Slides => Set<Slide>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slide>().HasData(
                new Slide { Id = 1, SlideText = "TestSlide", QuestionText = "Hello?", SlideImageUrl = "testurl.com", Category = "Test" },
                new Slide { Id = 2, SlideText = "TestSlide2", QuestionText = "Hello?", SlideImageUrl = "testurl.com", Category = "Test" }
            );
        }
    }
}
