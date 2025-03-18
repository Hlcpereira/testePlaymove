using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hlcpereira.Playmove.Domain.Contracts.Repositories.Base
{
    public interface ICrudRepository<T> : IRepositoryBase<T> where T : class
    {
        public virtual void Add(T entity)
        {
            _dataContext.DbContext.Set<T>().Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dataContext.DbContext.AddAsync(entity);
        }

        public virtual void Modify(T entity)
        {
            _dataContext.DbContext.Set<T>().Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dataContext.DbContext.Set<T>().Remove(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dataContext.DbContext.Set<T>().AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dataContext.DbContext.Set<T>().AddRangeAsync(entities);
        }
    }
}