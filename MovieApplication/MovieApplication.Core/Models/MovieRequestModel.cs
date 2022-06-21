using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Core.Models
{
    public class MovieRequestModel
    {
        public int Page { get; set; }
        public bool TVShow { get; set; }
        public SearchModel Search { get; set; }
    }
}
