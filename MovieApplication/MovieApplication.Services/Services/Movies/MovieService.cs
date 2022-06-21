using AutoMapper;
using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using MovieApplication.Repositories.Repositories.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Services.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            this._movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieModel>> GetMovies(MovieRequestModel movieRequestModel, int userId)
        {
            try
            {
                var movieList = await _movieRepository.GetMovies(movieRequestModel);

                if (!movieList.Any())
                    return null;

                 var mappedMovieList = _mapper.Map<List<MovieModel>> (movieList);

                // get user rate for movies
                for (int i = 0; i < movieList.Count; i++)
                {
                    mappedMovieList[i].RatingByUser = movieList[i].Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;
                }

                return mappedMovieList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ",ex);
                throw ex;
            }
        }
        public async Task<MovieActorModel> GetMovieById(int movieId, int userId)
        {
            try
            {
                var movie = await _movieRepository.GetMovieById(movieId);

                if (movie == null)
                {
                    return null;
                }

                var mappedMovie = _mapper.Map<MovieActorModel>(movie);
               
                // get user rate for movie
                mappedMovie.RatingByUser = movie.Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;

                return mappedMovie;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                throw ex;
            }
        }
        public async Task<MovieModel> RateMovie(int movieId, int userId, int rating)
        {
            try
            {
                var ratedMovie = await _movieRepository.RateMovie(movieId, userId, rating);

                if (ratedMovie == null)
                    return null;

                var mappedRatedMovie = _mapper.Map<MovieModel>(ratedMovie);

                // get user rate for movie
                 mappedRatedMovie.RatingByUser = ratedMovie.Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;

                Console.WriteLine("Movie rating added.");

                return mappedRatedMovie;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                throw ex;
            }
        }
    }
}
