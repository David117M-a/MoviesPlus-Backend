using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string? Cover { get; set; }
        public virtual List<ActorMovie> Actors { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
