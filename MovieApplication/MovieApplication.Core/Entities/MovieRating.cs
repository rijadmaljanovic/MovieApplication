using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieApplication.Core.Entities
{
    public class MovieRating
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int Rating { get; set; }

    }
}
