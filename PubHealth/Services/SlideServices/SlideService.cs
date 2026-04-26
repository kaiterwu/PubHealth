using Microsoft.EntityFrameworkCore;
using PubHealth.Data;
using PubHealth.Models;
using PubHealth.DTOs.SlideDTOs;

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
                    SlideImageUrl = s.SlideImageUrl,
                    Category = s.Category
                }).FirstOrDefaultAsync();
            return currSlide;
        }

        public Task<GetSlideResponse> UpdateSlideAsync(int id, Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
