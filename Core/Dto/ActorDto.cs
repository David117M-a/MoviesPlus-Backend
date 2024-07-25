using Core.Entities;

namespace MoviesPlus.Dto
{
    public class ActorDto
    {
        public string Name { get; set; }
        public string? Photo { get; set; }
        public List<int>? Movies { get; set; }
    }
}
