using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    interface IMovieSearch
    {
        IEnumerable<Movies> Search(string title);
        Movies FullInfo(string imdbId);
    }
}
