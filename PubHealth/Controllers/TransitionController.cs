using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubHealth.DTOs.TransitionDTOs;
using PubHealth.Models;
using PubHealth.Services.TransitionServices;
namespace PubHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransitionController(ITransitionService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetTransitionResponse>>> GetTransitions()
            => Ok(await service.GetAllTransitionsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTransitionResponse>>GetTransition(int id)
        {
            var transition = await service.GetTransitionByIdAsync(id);
            return transition is null ? NotFound($"No transition found with id {id}") : Ok(transition);
        }
    }
}
