using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public bool Show { get; set; } //TVShow
        public float AvgRating { get; set; }
        public int RatingByUser { get; set; }
    }
}
