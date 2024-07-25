using Business.Contracts.Services;
using Core.Contracts.Services;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesPlus.Dto;

namespace MoviesPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Movie>? movies = _moviesService.GetAllMovies();
            if (movies == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(movies);
        }

        [HttpGet("byTitle/{title}")]
        public IActionResult GetAllByTitle(string title)
        {
            IEnumerable<Movie>? movies = _moviesService.GetMoviesByTitle(title);
            if (movies == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(movies);
        }

        [HttpGet("byGenre/{genreId}")]
        public IActionResult GetAllByGenre(int genreId)
        {
            IEnumerable<Movie>? movies = _moviesService.GetMoviesByGenre(genreId);
            if (movies == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(movies);
        }

        [HttpGet("byActor/{actorId}")]
        public IActionResult GetAllByActor(int actorId)
        {
            IEnumerable<Movie>? movies = _moviesService.GetMoviesByActor(actorId);
            if (movies == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(movies);
        }

        [HttpGet("byMultipleFilters")]
        public IActionResult GetByMultipleFilters([FromQuery] string? title, [FromQuery] int? genreId, [FromQuery] int? actorId)
        {
            IEnumerable<Movie>? movies = _moviesService.GetMoviesByMultipleFilters(title, genreId, actorId);
            if (movies == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieDto movieDto)
        {
            if (string.IsNullOrEmpty(movieDto.Title))
            {
                return BadRequest(new { message = "Movie title is mandatory" });
            }

            if (movieDto.GenreId <= 0)
            {
                return BadRequest(new { message = "Movie genre is mandatory" });
            }

            Movie? newMovie = await _moviesService.CreateMovie(movieDto);
            if (newMovie == null)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok(newMovie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _moviesService.DeleteMovie(id);
            if (!result)
            {
                return BadRequest(new { message = "We are having some troubles, try it later" });
            }

            return Ok();
        }
    }
}
