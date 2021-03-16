using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Movie.Model;
using Newtonsoft.Json;

namespace Movie.Services
{
    class MovieSearch : IMovieSearch
    {
        public IEnumerable<Movies> Search(string title)
        {
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString($"http://www.omdbapi.com/?apikey=2c9d65d5&s={title}");
            dynamic data = JsonConvert.DeserializeObject(json);
            var list = new List<Movies>();
            foreach (var item in data.Search)
            {
                list.Add(new Movies
                {
                    Title = item.Title.ToString(),
                    Id = item.imdbID.ToString()
                });
            }
            return list;
        }

        public Movies FullInfo(string imdbId)
        {
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString($"http://www.omdbapi.com/?apikey=2c9d65d5&i={imdbId}");
            dynamic data = JsonConvert.DeserializeObject(json);
            var movie = new Movies
            {
                Title = data.Title.ToString(),
                Year = data.Year.ToString(),
                Poster = data.Poster.ToString(),
                Genre = data.Genre.ToString(),
                Plot = data.Plot.ToString(),
                Id = data.imdbID.ToString()
            };
            return movie;
        }
    }
}
