using Core.Entities;
using MoviesPlus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor>? GetAllActors();
        Task<Actor?> CreateActor(ActorDto actorDto);
        Task<bool> DeleteActor(int id);
    }
}
