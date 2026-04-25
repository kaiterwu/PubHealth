using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubHealth.Models;
using PubHealth.Services;

namespace PubHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController(ISlideService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Slide>>> GetSlides()
            => Ok(await service.GetAllSlidesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Slide>> GetSlide(int id)
        {
            var slide = await service.GetSlideByIdAsync(id);
            return slide is null ? NotFound("Slide with id not found") : Ok(slide);

        }
    }
}
