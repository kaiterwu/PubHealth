using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubHealth.Models;

namespace PubHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        static List<Slide> slides = new List<Slide>
        {
            new Slide
            {
                Id = 1,
                IsFork = false,
                SlideText = "Welcome to the PubHealth presentation!",
                QuestionText = "What is PubHealth?",
                SlideImageUrl = "https://example.com/slide1.jpg"
            },
            new Models.Slide
                {
                    Id = 2,
                    IsFork = true,
                    SlideText = "PubHealth is a platform for public health education.",
                    QuestionText = "How does PubHealth work?",
                    SlideImageUrl = "https://example.com/slide2.jpg"
                }
        };
        [HttpGet]
        public async Task<ActionResult<List<Slide>>>GetSlides()
            => await Task.FromResult(Ok(slides));
    }
}
