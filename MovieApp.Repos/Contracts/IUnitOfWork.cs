using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
