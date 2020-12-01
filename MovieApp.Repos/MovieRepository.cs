using MovieApp.data.Models;
using MovieApp.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Repos
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly MovieDBContext _DbContext;

        public MovieRepository(MovieDBContext context): base(context)
        {
            this._DbContext = context;
        }

        public IEnumerable<Movie> GetTopMovieInAYear(int year, int count)
        {
            return (from m in _DbContext.Movies
                    .Include("Genre")
                    .Include("Director")
                    orderby m.Rating descending
                    where m.ReleaseDate.Year.Equals(year)
                    select m).Take(count);
        }
    }
}
