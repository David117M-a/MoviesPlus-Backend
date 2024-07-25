using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public virtual List<ActorMovie> Movies { get; set; }
    }
}
