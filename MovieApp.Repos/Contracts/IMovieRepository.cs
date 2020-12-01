using MovieApp.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Repos.Contracts
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetTopMovieInAYear(int year, int count);
    }
}
