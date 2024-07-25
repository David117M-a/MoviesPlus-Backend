using Core.Contracts.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Genre>? genres = _genresService.GetAllGenres();
            if (genres == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(genres);
        }
    }
}
