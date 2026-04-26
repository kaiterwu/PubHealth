using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubHealth.DTOs.SlideDTOs;
using PubHealth.Models;
using PubHealth.Services.SlideServices;

namespace PubHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController(ISlideService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetSlideResponse>>> GetSlides()
            => Ok(await service.GetAllSlidesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSlideResponse>> GetSlide(int id)
        {
            var slide = await service.GetSlideByIdAsync(id);
            return slide is null ? NotFound("Slide with id not found") : Ok(slide);

        }
    }
}
