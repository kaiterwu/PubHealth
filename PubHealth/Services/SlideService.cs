using PubHealth.Models;

namespace PubHealth.Services
{
    public class SlideService : ISlideService
    {
        static List<Slide> slides = new List<Slide>
        {
            new Slide
            {
                Id = 1,
                IsFork = false,
                SlideText = "Welcome to the PubHealth presentation!",
                QuestionText = "What is PubHealth?",
                SlideImageUrl = "https://example.com/slide1.jpg",
                Category = "Introduction"
            },
            new Models.Slide
                {
                    Id = 2,
                    IsFork = true,
                    SlideText = "PubHealth is a platform for public health education.",
                    QuestionText = "How does PubHealth work?",
                    SlideImageUrl = "https://example.com/slide2.jpg",
                    Category = "Introduction"
                }
        };
        public Task<Slide> CreateSlideAsync(Slide slide)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSlideAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Slide>> GetAllSlidesAsync()
            => await Task.FromResult((slides));

        public async Task<Slide?> GetSlideByIdAsync(int id)
        {
            var currSlide = slides.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(currSlide);
        }

        public Task<Slide> UpdateSlideAsync(int id, Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
