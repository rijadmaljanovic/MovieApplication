using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Entities
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
