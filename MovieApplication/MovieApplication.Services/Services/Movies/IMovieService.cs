using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Services.Services.Movies
{
    public interface IMovieService
    {
        Task<List<MovieModel>> GetMovies(MovieRequestModel movieRequestModel, int userId);
        Task<MovieActorModel> GetMovieById(int movieId,int userId);
        Task<MovieModel> RateMovie(int movieId, int userId, int rating);

    }
}
