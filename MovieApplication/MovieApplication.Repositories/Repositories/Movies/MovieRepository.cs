using Microsoft.EntityFrameworkCore;
using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using MovieApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repositories.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _databaseContext;
        public MovieRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<Movie>> GetMovies(MovieRequestModel movieRequestModel)
        {
            try
            {
                var itemsPerPage = 10;
                var list = await _databaseContext.Movies.Include(z=>z.Ratings).ToListAsync();

                return list
                .Where(m => m.Show == movieRequestModel.TVShow && Search(m, movieRequestModel.Search))
                .OrderByDescending(m => m.Ratings.Any() ? m.Ratings.Average(mr => mr.Rating) : 0)
                .Skip(itemsPerPage * (movieRequestModel.Page - 1))
                .Take(10)
                .ToList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                throw ex;
            }
        }

        private bool Search(Movie movie, SearchModel searchModel)
        {
            if (searchModel == null)
            {
                return true;
            }
            else
            {
                searchModel.Value = searchModel.Value.ToLower();

                var x = movie.MovieTitle.ToLower().Contains(searchModel.Value) ||
                        movie.Description.Substring(0, movie.Description.Length > 200 ? 200 : movie.Description.Length).ToLower().Contains(searchModel.Value);
                return x;
            }
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            var movie= await _databaseContext.Movies.Include(r=>r.Ratings).Include(x=>x.Actors).ThenInclude(z=>z.Actor).FirstOrDefaultAsync(m => m.Id == movieId);

            return movie;
        }

        public async Task<Movie> RateMovie(int movieId, int userId, int rating)
        {
            if (!await _databaseContext.Movies.AnyAsync(m => m.Id == movieId))
                return null;

            var movieRating = await _databaseContext.MovieRatings.FirstOrDefaultAsync(mr => mr.UserId == userId && mr.MovieId == movieId);

            if (movieRating == null)
            {
                await _databaseContext.MovieRatings.AddAsync(
                    new MovieRating { UserId = userId, MovieId = movieId, Rating = rating });
            }
            else
            {
                movieRating.Rating = rating;
            }

            await _databaseContext.SaveChangesAsync();

            return await _databaseContext.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
        }
    }
}
