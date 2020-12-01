using MovieApp.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Repos.Contracts
{
    public interface IDirectorRepository
    {
        IEnumerable<Director> GetAllDirectorByMovieLanguage(string language);
    }
}
