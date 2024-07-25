using Business.Contracts.Repositories;
using Core.Contracts.Services;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GenresService : IGenresService
    {
        private readonly IRepositoryBase<Genre> _genreRepository;
        public GenresService(IRepositoryBase<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<Genre>? GetAllGenres()
        {
            try
            {
                return _genreRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
