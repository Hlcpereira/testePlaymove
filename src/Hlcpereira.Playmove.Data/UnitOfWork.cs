using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Hlcpereira.Playmove.Domain.Contracts.DataContext;
using Hlcpereira.Playmove.Domain.Contracts.Persistance;

namespace Hlcpereira.Playmove.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IDataContext dataContext)
        {
            _context = dataContext.DbContext;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}