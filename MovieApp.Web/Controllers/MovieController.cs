using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Repos;
using MovieApp.Repos.Contracts;

namespace MovieApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly UnitOfWork _UoW;

        public MovieController(IUnitOfWork uow)
        {
            this._UoW = uow as UnitOfWork;
        }
        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Movies = this._UoW.movieRepository.GetTopMovieInAYear(2016, 5);            
            return View("MoviesDetailView", model);
        }
    }
}
