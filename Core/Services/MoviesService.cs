using Business.Contracts.Repositories;
using Core.Contracts.Services;
using Core.Entities;
using MoviesPlus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepositoryBase<Movie> _movieRepository;
        private readonly IRepositoryBase<Actor> _actorRepository;
        private readonly IRepositoryBase<ActorMovie> _actorMovieRepository;
        public MoviesService(IRepositoryBase<Movie> movieRepository, IRepositoryBase<Actor> actorRepository, IRepositoryBase<ActorMovie> actorMovieRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _actorMovieRepository = actorMovieRepository;
        }

        public IEnumerable<Movie>? GetAllMovies()
        {
            try
            {
                return _movieRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Movie>? GetMoviesByTitle(string title)
        {
            try
            {
                return _movieRepository.GetAll(m => m.Title.Contains(title.ToLower()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Movie>? GetMoviesByGenre(int genreId)
        {
            try
            {
                return _movieRepository.GetAll(m => m.GenreId == genreId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Movie>? GetMoviesByActor(int actorId)
        {
            try
            {
                IEnumerable<ActorMovie> actorMovie = _actorMovieRepository.GetAll(am => am.ActorId == actorId).ToList();
                return actorMovie.Select(am =>
                {
                    return _movieRepository.Find(m => m.Id == am.MovieId);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Movie>? GetMoviesByMultipleFilters(string? title, int? genreId, int? actorId)
        {
            try
            {
                if (string.IsNullOrEmpty(title) && genreId <= 0 && actorId <= 0)
                {
                    return _movieRepository.GetAll();
                }

                IEnumerable<Movie> movies = _movieRepository.GetAll().ToList();
                if (!string.IsNullOrEmpty(title))
                {
                    movies = movies.Where(m => m.Title.Contains(title.ToLower()));
                }

                if (genreId > 0)
                {
                    movies = movies.Where(m => m.GenreId == genreId);
                }

                if (actorId > 0)
                {
                    IEnumerable<int> actorMovies = _actorMovieRepository.GetAll(am => am.ActorId == actorId).Select(am => am.MovieId).ToList();
                    movies = movies.Where(m => actorMovies.Contains(m.Id));
                }

                return movies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Movie?> CreateMovie(MovieDto movieDto)
        {
            try
            {
                Movie newMovie = new Movie();
                newMovie.Title = movieDto.Title.ToLower();
                newMovie.GenreId = movieDto.GenreId;
                newMovie.Cover = movieDto.Cover;
                newMovie = await _movieRepository.Create(newMovie);

                if (movieDto.Actors?.Count > 0)
                {
                    foreach (int actor in movieDto.Actors)
                    {
                        Actor actorToSave = _actorRepository.Find(m => m.Id == actor);
                        if (actorToSave != null)
                        {
                            ActorMovie actorMovie = new ActorMovie();
                            actorMovie.ActorId = actor;
                            actorMovie.MovieId = newMovie.Id;
                            actorMovie = await _actorMovieRepository.Create(actorMovie);
                        }
                    }
                }

                return newMovie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            try
            {
                Movie movie = _movieRepository.Find(a => a.Id == id);
                if (movie == null)
                    return false;

                await _movieRepository.Delete(movie);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
