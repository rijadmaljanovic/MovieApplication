using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Core.Helpers;
using MovieApplication.Core.Models;
using MovieApplication.Services.Services.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Backoffice.Controllers
{
    [Authorize]
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<ActionResult<List<MovieModel>>> GetMovies([FromBody] MovieRequestModel movieRequestModel)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var list = await _movieService.GetMovies(movieRequestModel, userId);

                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("{movieId:int}")]
        public async Task<ActionResult<MovieActorModel>> GetMovieById([FromRoute] int movieId)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var movie = await _movieService.GetMovieById(movieId, userId);

                if (movie == null)
                    return NotFound();

                return Ok(movie);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("rate/{movieId:int}")]
        public async Task<ActionResult<MovieModel>> RateMovie([FromRoute] int movieId, [FromBody] int rating)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var updatedMovie = await _movieService.RateMovie(movieId, userId, rating);

                if (updatedMovie == null)
                    return BadRequest("Movie is not rated!");

                return Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }
    }
}
