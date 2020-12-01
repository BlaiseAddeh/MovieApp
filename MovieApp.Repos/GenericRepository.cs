using Microsoft.EntityFrameworkCore;
using MovieApp.data.Models;
using MovieApp.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Repos
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MovieDBContext _DbContext;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(MovieDBContext context)
        {
            this._DbContext = context;
            this._DbSet = this._DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            this._DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this._DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._DbSet.ToList();
        }

        public T GetById(int id)
        {
            return this._DbSet.Find(id);
        }

        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
            this._DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
