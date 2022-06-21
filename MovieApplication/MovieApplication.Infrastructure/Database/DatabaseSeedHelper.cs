using MovieApplication.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieApplication.Infrastructure.Database
{
    public static class DatabaseSeedHelper
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private static string JsonFilesLocation = Path.GetFullPath(Path.Combine(CurrentDirectory, @"..\\MovieApplication.Infrastructure\\Database\\MovieData\\"));

        public static List<Movie> GetMovies()
        {
            dynamic array = ReadJSONFile("Movies.json");

            var movieList = new List<Movie>();

            for (int i = 0; i < array.Count; i++)
            {
                movieList.Add(new Movie
                {
                    Description = array[i].overview,
                    ReleaseDate = array[i].release_date,
                    MovieTitle = array[i].title,
                    Show = i % 3 == 0,
                    ImagePath = array[i].poster_path?.ToString() ?? ""
                });
            }

            foreach (var movie in movieList)
            {
                if (!String.IsNullOrEmpty(movie.ImagePath))
                    movie.ImagePath = "Images/Movies" + movie.ImagePath;
            }

            return movieList;
        }

        public static List<Actor> GetActors()
        {
            dynamic array = ReadJSONFile("Actors.json");

            var actorsList = new List<Actor>();
            foreach (var actorInJSON in array)
            {
                actorsList.Add(new Actor
                {
                    Name = actorInJSON.name,
                    ImagePath = actorInJSON.profile_path?.ToString() ?? ""
                });
            }
            foreach (var actor in actorsList)
            {
                if (!String.IsNullOrEmpty(actor.ImagePath))
                    actor.ImagePath = "Images/Actors" + actor.ImagePath;
            }

            return actorsList;
        }

        private static dynamic ReadJSONFile(string fileName)
        {
            string json = "";

            using (StreamReader r = new StreamReader(JsonFilesLocation + fileName))
            {
                json = r.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(json);
        }
    }
}
