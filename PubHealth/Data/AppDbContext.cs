using Microsoft.EntityFrameworkCore;
using PubHealth.Models;

namespace PubHealth.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Slide> Slides => Set<Slide>();
        public DbSet<Transition> Transitions => Set<Transition>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------
            // Slide (node table)
            // -----------------------
            modelBuilder.Entity<Slide>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id)
                      .ValueGeneratedNever(); // IMPORTANT for fixed IDs
                entity.Property(s => s.SlideText);
                entity.Property(s => s.QuestionText);
                entity.Property(s => s.SlideImageUrl);
                entity.Property(s => s.ExplanationText);
                entity.Property(s => s.Category)
                      .IsRequired();
            });

            modelBuilder.Entity<Slide>().HasData(
                new Slide
                {
                    Id = 1,
                    SlideText = "TestSlide",
                    QuestionText = "Hello?",
                    SlideImageUrl = "testurl.com",
                    Category = "Test",
                    IsFork = false
                },
                new Slide
                {
                    Id = 2,
                    SlideText = "TestSlide2",
                    QuestionText = "Hello?",
                    SlideImageUrl = "testurl.com",
                    Category = "Test",
                    IsFork = false
                },
                new Slide
                {
                    Id = 3,
                    SlideText = "TestSlide3",
                    QuestionText = "Why?",
                    SlideImageUrl = "testurl.com",
                    Category = "Test",
                    IsFork = false
                },
                new Slide
                {
                    Id = 4,
                    SlideText = "TestSlide4",
                    QuestionText = "SO many slides why?",
                    SlideImageUrl = "testurl.com",
                    Category = "NewTest",
                    IsFork = true
                }
            );

            // -----------------------
            // Transition (edge table)
            // -----------------------
            modelBuilder.Entity<Transition>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                      .ValueGeneratedNever(); // IMPORTANT for fixed IDs

                entity.Property(t => t.ParentSlideId)
                      .IsRequired();

                entity.Property(t => t.ChildSlideId)
                      .IsRequired();

                entity.Property(t => t.AnswerText1);

                entity.Property(t => t.AnswerText2);
            });

            modelBuilder.Entity<Transition>().HasData(
                new Transition
                {
                    Id = 1,
                    ParentSlideId = 1,
                    ChildSlideId = 2,
                    AnswerText1 = "Answer1",
                    AnswerText2 = "Answer2"
                },
                new Transition
                {
                    Id = 2,
                    ParentSlideId = 1,
                    ChildSlideId = 3,
                    AnswerText1 = "Answer3",
                    AnswerText2 = "Answer4"
                },
                new Transition
                {
                    Id = 3,
                    ParentSlideId = 2,
                    ChildSlideId = 4,
                    AnswerText1 = "Answer5",
                    AnswerText2 = "Answer6"
                },
                new Transition
                {
                    Id = 4,
                    ParentSlideId = 3,
                    ChildSlideId = 4,
                    AnswerText1 = "Answer7",
                    AnswerText2 = "Answer8"
                }
            );
        }
    }
}
