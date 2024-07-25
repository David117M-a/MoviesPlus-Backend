using Core.Entities;
using MoviesPlus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts.Services
{
    public interface IMoviesService
    {
        IEnumerable<Movie>? GetAllMovies();
        IEnumerable<Movie>? GetMoviesByTitle(string title);
        IEnumerable<Movie>? GetMoviesByGenre(int genreId);
        IEnumerable<Movie>? GetMoviesByActor(int actorId);
        IEnumerable<Movie>? GetMoviesByMultipleFilters(string? title, int? genreId, int? actorId);
        Task<Movie?> CreateMovie(MovieDto movieDto);
        Task<bool> DeleteMovie(int id);
    }
}
