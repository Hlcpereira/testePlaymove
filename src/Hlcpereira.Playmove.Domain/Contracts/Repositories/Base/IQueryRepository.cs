using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Hlcpereira.Playmove.CrossCutting.Utilities.Paging;

namespace Hlcpereira.Playmove.Domain.Contracts.Repositories.Base
{
    public interface IQueryRepository<T> : IRepositoryBase<T>
        where T : class
    {
        public virtual int Count(Expression<Func<T, bool>> where = null)
        {
            where ??= (x => true);
            return _dataContext.DbContext.Set<T>().Count(where);
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            where ??= (x => true);
            return _dataContext.DbContext.Set<T>().CountAsync(where);
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return _dataContext.DbContext.Set<T>().Any(where);
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return _dataContext.DbContext.Set<T>().AnyAsync(where);
        }

        public virtual T FindByKey(params object[] keyValues)
        {
            return _dataContext.DbContext.Set<T>().Find(keyValues);
        }

        public virtual ValueTask<T> FindByKeyAsync(params object[] keyValues)
        {
            return _dataContext.DbContext.Set<T>().FindAsync(keyValues);
        }

        public virtual T Find(Expression<Func<T, bool>> where, IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).FirstOrDefault(where);
        }

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> where, IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).FirstOrDefaultAsync(where);
        }

        public virtual T Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).FirstOrDefault(where);
        }

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).FirstOrDefaultAsync(where);
        }

        public virtual IQueryable<T> List(IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes);
        }

        public virtual IQueryable<T> List(params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes);
        }

        public virtual IQueryable<T> List(List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes)
        {
            return CurrentSet(includes: includes);
        }

        public virtual IQueryable<T> List(
            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes,
            Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null)
        {
            return CurrentSet(includes: includes, where: where, SortField: SortField, SortType: SortType, page: page, PageSize: PageSize);
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes);
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes);
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> where, IPagination pagination, IEnumerable<string> includes = null)
        {
            return CurrentSet(where,
                pagination.PageIndex,
                pagination.PageSize,
                pagination.SortField,
                pagination.SortType,
                includes);
        }

        public virtual IQueryable<T> List(
            Expression<Func<T, bool>> where,
            IPagination pagination,
            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null
            )
        {
            return CurrentSet(
                includes: includes,
                where: where,
                SortField: pagination.SortField,
                SortType: pagination.SortType,
                page: pagination.PageIndex,
                PageSize: pagination.PageSize
            );
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> where, IPagination pagination, params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(where,
                pagination.PageIndex,
                pagination.PageSize,
                pagination.SortField,
                pagination.SortType,
                includes);
        }

        public virtual PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination, params Expression<Func<T, object>>[] includes)
        {
            var total = Count(where);

            var itens = List(where, pagination, includes);

            return new PagedList<T>(itens, total, pagination.PageSize);
        }
    }
}