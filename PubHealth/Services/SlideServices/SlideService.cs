using Microsoft.EntityFrameworkCore;
using PubHealth.Data;
using PubHealth.DTOs.SlideDTOs;
using PubHealth.DTOs.TransitionDTOs;
using PubHealth.Models;

namespace PubHealth.Services.SlideServices
{
    public class SlideService(AppDbContext context) : ISlideService
    {
        public Task<GetSlideResponse> CreateSlideAsync(Slide slide)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSlideAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<GetSlideResponse> UpdateSlideAsync(int id, Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
