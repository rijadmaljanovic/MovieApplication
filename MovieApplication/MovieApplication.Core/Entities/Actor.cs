using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Entities
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<MovieActor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<MovieActor> Movies { get; set; }
    }
}
