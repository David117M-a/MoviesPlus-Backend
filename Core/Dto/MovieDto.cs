using Core.Entities;

namespace MoviesPlus.Dto
{
    public class MovieDto
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string? Cover { get; set; }
        public List<int>? Actors { get; set; }
    }
}
