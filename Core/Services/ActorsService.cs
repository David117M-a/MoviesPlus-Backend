using Business.Contracts.Repositories;
using Business.Contracts.Services;
using Core.Entities;
using MoviesPlus.Dto;

namespace Business.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IRepositoryBase<Actor> _actorRepository;
        private readonly IRepositoryBase<ActorMovie> _actorMovieRepository;
        private readonly IRepositoryBase<Movie> _movieRepository;
        public ActorsService(IRepositoryBase<Actor> actorRepository, IRepositoryBase<ActorMovie> actorMovieRepository, IRepositoryBase<Movie> movieRepository)
        {
            _actorRepository = actorRepository;
            _actorMovieRepository = actorMovieRepository;
            _movieRepository = movieRepository;
        }

        public IEnumerable<Actor>? GetAllActors()
        {
            try
            {
                return _actorRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Actor?> CreateActor(ActorDto actorDto)
        {
            try
            {
                Actor newActor = new Actor();
                newActor.Name = actorDto.Name.ToLower();
                newActor.Photo = actorDto.Photo;
                newActor = await _actorRepository.Create(newActor);

                if (actorDto.Movies?.Count > 0)
                {
                    newActor.Movies = new List<ActorMovie>();
                    foreach (int movie in actorDto.Movies)
                    {
                        Movie movieToSave = _movieRepository.Find(m => m.Id == movie);
                        if (movieToSave != null)
                        {
                            ActorMovie actorMovie = new ActorMovie();
                            actorMovie.ActorId = newActor.Id;
                            actorMovie.MovieId = movie;
                            actorMovie = await _actorMovieRepository.Create(actorMovie);
                        }
                    }
                }

                return newActor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteActor(int id)
        {
            try
            {
                Actor actor = _actorRepository.Find(a => a.Id == id);
                if (actor == null)
                    return false;

                await _actorRepository.Delete(actor);
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
