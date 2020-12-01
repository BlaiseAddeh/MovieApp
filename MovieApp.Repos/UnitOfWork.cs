using MovieApp.data.Models;
using MovieApp.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDBContext _DbContext;
        public MovieRepository movieRepository { get; private set; }

        public UnitOfWork(MovieDBContext context)
        {
            _DbContext = context;
            this.movieRepository = new MovieRepository(this._DbContext);
        }

        public async Task Commit()
        {
            await this._DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }
    }
}
