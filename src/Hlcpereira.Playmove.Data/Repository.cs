using Microsoft.EntityFrameworkCore;

using Hlcpereira.Playmove.Domain.Contracts.DataContext;
using Hlcpereira.Playmove.Domain.Contracts.Repositories;

namespace Hlcpereira.Playmove.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public IDataContext _dataContext { get; }
        
        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _context = dataContext.DbContext;
        }
    }
}