using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Models
{
    public class MovieActorModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string ImagePath { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public bool Show { get; set; }
        public float AvgRating { get; set; }
        public int RatingByUser { get; set; }
        public List<ActorModel> Actors { get; set; }
    }
}
