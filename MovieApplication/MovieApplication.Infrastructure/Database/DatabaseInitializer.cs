using MovieApplication.Core.Entities;
using MovieApplication.Core.Helpers;
using MovieApplication.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MovieApplication.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            var Random = new Random();

            //check are there any users in the Db
            if (!context.Users.Any())
            {
                #region UserData seed

                var userList = new List<User>();

                for (int i = 1; i <= 5; i++)
                {
                    var salt = PasswordHashSaltGenerator.GenerateSalt();

                    var usernamePassword = "User" + i;

                    userList.Add(new User
                    {
                        Username = usernamePassword,
                        PasswordSalt = salt,
                        PasswordHash = PasswordHashSaltGenerator.HashPassword(salt, usernamePassword)
                    });
                }

                context.Users.AddRange(userList);
                context.SaveChanges();

                userList = userList.OrderBy(u => u.Id).ToList();
                var userIdMin = userList.First().Id;
                var userIdMax = userList.Last().Id;

                #endregion

                #region MovieData seed

                var movieList = DatabaseSeedHelper.GetMovies();
                context.Movies.AddRange(movieList);
                context.SaveChanges();

                movieList = movieList.OrderBy(m => m.Id).ToList();
                var movieIdMin = movieList.First().Id;
                var movieIdMax = movieList.Last().Id;

                #endregion

                #region MovieRatingData seed

                var movieRatingsList = new List<MovieRating>();
                var allMovies = movieList.Count;
                var allUsers = userList.Count;
                for (int i = 0; i < allMovies * 3; i++)
                {
                    var movieRatingForAdd = new MovieRating
                    {
                        MovieId = Random.Next(movieIdMin, movieIdMax + 1),
                        UserId = Random.Next(userIdMin, userIdMax + 1),
                        Rating = Random.Next(1, 6)
                    };

                    if (movieRatingsList.Find(mr => mr.MovieId == movieRatingForAdd.MovieId && mr.UserId == movieRatingForAdd.UserId) == null)
                        movieRatingsList.Add(movieRatingForAdd);
                }

                context.MovieRatings.AddRange(movieRatingsList);
                context.SaveChanges();

                #endregion

                #region ActorData seed

                var actorList = DatabaseSeedHelper.GetActors();
                context.Actors.AddRange(actorList);
                context.SaveChanges();

                actorList = actorList.OrderBy(a => a.Id).ToList();
                var actorIdMin = actorList.First().Id;
                var actorIdMax = actorList.Last().Id;

                #endregion

                #region MovieActorData seed

                var movieActorList = new List<MovieActor>();
                for (int i = 0; i < movieList.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var movieActorForAdd = new MovieActor
                        {
                            MovieId = movieList[i].Id,
                            ActorId = Random.Next(actorIdMin, actorIdMax + 1),
                        };

                        if (movieActorList.Find(ma => ma.ActorId == movieActorForAdd.ActorId && ma.MovieId == movieActorForAdd.MovieId) == null)
                            movieActorList.Add(movieActorForAdd);
                    }
                }

                context.MovieActors.AddRange(movieActorList);
                context.SaveChanges();

                #endregion
            }
            else
            {
                return;
            }

        }
    }

}
