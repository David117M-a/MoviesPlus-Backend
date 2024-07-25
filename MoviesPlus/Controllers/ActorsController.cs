using Business.Contracts.Services;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesPlus.Dto;

namespace MoviesPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;
        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Actor>? actors = _actorsService.GetAllActors();
            if (actors == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(actors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActorDto actor)
        {
            if (string.IsNullOrEmpty(actor.Name))
            {
                return BadRequest(new { message = "Actor name is mandatory" });
            }

            Actor? newActor = await _actorsService.CreateActor(actor);
            if (newActor == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(newActor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _actorsService.DeleteActor(id);
            if (!result)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok();
        }
    }
}
