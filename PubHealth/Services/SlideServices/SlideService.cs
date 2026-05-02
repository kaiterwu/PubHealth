using Microsoft.EntityFrameworkCore;
using PubHealth.Data;
using PubHealth.DTOs.SlideDTOs;
using PubHealth.DTOs.TransitionDTOs;
using PubHealth.Models;

namespace PubHealth.Services.SlideServices
{
    public class SlideService(AppDbContext context) : ISlideService
    {
        public async Task<GetSlideResponse> CreateSlideAsync(CreateSlideRequest slide)
        {
            var newSlide = new Slide
            {
                Id = slide.Id,
                IsFork = slide.IsFork,
                SlideText = slide.SlideText,
                QuestionText = slide.QuestionText,
                ExplanationText = slide.ExplanationText,
                SlideImageUrl = slide.SlideImageUrl,
                Category = slide.Category
            };

            context.Slides.Add(newSlide);
            await context.SaveChangesAsync();

            return new GetSlideResponse
            {
                Id = newSlide.Id,
                IsFork = newSlide.IsFork,
                SlideText = newSlide.SlideText,
                QuestionText = newSlide.QuestionText,
                ExplanationText = newSlide.ExplanationText,
                SlideImageUrl = newSlide.SlideImageUrl,
                Category = newSlide.Category
            };
        }

        public async Task<bool> DeleteSlideAsync(int id)
        {
            var slideToDelete = await context.Slides.FindAsync(id) ?? throw new Exception($"Slide with ID {id} not found.");
            context.Slides.Remove(slideToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetSlideResponse>> GetAllSlidesAsync()
            => await context.Slides.Select(s => new GetSlideResponse
            {
                Id = s.Id,
                IsFork = s.IsFork,
                SlideText = s.SlideText,
                QuestionText = s.QuestionText,
                ExplanationText = s.ExplanationText,
                SlideImageUrl = s.SlideImageUrl,
                Category = s.Category
            }).ToListAsync();

        public async Task<GetSlideResponse?> GetSlideByIdAsync(int id)
        {
            var currSlide = await context.Slides
                .Where(s=> s.Id == id)
                .Select( s => new GetSlideResponse
                {
                    Id = s.Id,
                    IsFork = s.IsFork,
                    SlideText = s.SlideText,
                    QuestionText = s.QuestionText,
                    ExplanationText = s.ExplanationText,
                    SlideImageUrl = s.SlideImageUrl,
                    Category = s.Category
                }).FirstOrDefaultAsync();
            return currSlide;
        }

        public async Task<GetSlideResponse?> GetFirstSlideByCategoryAsync(string category)
        {
            return await context.Slides
                .Where(s => s.Category.ToLower() == category.ToLower())
                .OrderBy(s => s.Id) // ensures "first"
                .Select(s => new GetSlideResponse
                {
                    Id = s.Id,
                    IsFork = s.IsFork,
                    SlideText = s.SlideText,
                    QuestionText = s.QuestionText,
                    ExplanationText = s.ExplanationText,
                    SlideImageUrl = s.SlideImageUrl,
                    Category = s.Category
                })
                .FirstOrDefaultAsync();
        }
        public async Task<GetSlideWithTransitionsResponse?> GetSlideWithTransitionsAsync(int slideId)
        {
            var slide = await context.Slides
                .Where(s => s.Id == slideId)
                .Select(s => new GetSlideResponse
                {
                    Id = s.Id,
                    IsFork = s.IsFork,
                    SlideText = s.SlideText,
                    QuestionText = s.QuestionText,
                    SlideImageUrl = s.SlideImageUrl,
                    Category = s.Category
                })
                .FirstOrDefaultAsync();

            if (slide == null)
                return null;

            var transitions = await context.Transitions
                .Where(t => t.ParentSlideId == slideId)
                .Select(t => new GetTransitionResponse
                {
                    Id = t.Id,
                    ParentSlideId = t.ParentSlideId,
                    ChildSlideId = t.ChildSlideId,
                    AnswerText1 = t.AnswerText1,
                    IsCorrectChoice = t.IsCorrectChoice
                })
                .ToListAsync();

            return new GetSlideWithTransitionsResponse
            {
                Slide = slide,
                Transitions = transitions
            };
        }

        public async Task<GetSlideResponse> UpdateSlideAsync(int id, UpdateSlideRequest slide)
        {
            var existingSlide = await context.Slides.FindAsync(id) ?? throw new Exception($"Slide with ID {id} not found.");
            existingSlide.IsFork = slide.IsFork;
            existingSlide.SlideText = slide.SlideText;
            existingSlide.QuestionText = slide.QuestionText;
            existingSlide.ExplanationText = slide.ExplanationText;
            existingSlide.SlideImageUrl = slide.SlideImageUrl;
            existingSlide.Category = slide.Category;

            await context.SaveChangesAsync();

            return new GetSlideResponse
            {
                Id = existingSlide.Id,
                IsFork = existingSlide.IsFork,
                SlideText = existingSlide.SlideText,
                QuestionText = existingSlide.QuestionText,
                ExplanationText = existingSlide.ExplanationText,
                SlideImageUrl = existingSlide.SlideImageUrl,
                Category = existingSlide.Category
            };
        }
    }
}
