using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Entities
{
    public class Movie
    {
        public Movie()
        {
            Ratings = new HashSet<MovieRating>();
            this.Actors = new HashSet<MovieActor>();

        }
        public int Id{ get; set; }
        public string MovieTitle{ get; set; }
        public DateTime ReleaseDate{ get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool Show{ get; set; } //TVShow
        public virtual ICollection<MovieRating> Ratings { get; set; }
        public virtual ICollection<MovieActor> Actors { get; set; }
    }
}
