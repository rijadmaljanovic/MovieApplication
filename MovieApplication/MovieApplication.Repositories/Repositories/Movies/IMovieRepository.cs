using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repositories.Repositories.Movies
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies(MovieRequestModel movieRequestModel);
        Task<Movie> GetMovieById(int movieId);
        Task<Movie> RateMovie(int movieId, int userId, int rating);
    }
}
