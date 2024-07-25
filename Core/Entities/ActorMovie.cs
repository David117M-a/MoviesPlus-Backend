using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        [JsonIgnore]
        public virtual Actor Actor { get; set; }
        [JsonIgnore]
        public virtual Movie Movie { get; set; }
    }
}
