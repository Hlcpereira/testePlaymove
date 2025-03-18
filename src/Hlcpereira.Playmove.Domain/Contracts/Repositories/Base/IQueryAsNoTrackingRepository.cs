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
    public interface IQueryAsNoTrackingRepository<T> : IRepositoryBase<T>
        where T : class
    {
        public virtual T FindAsNoTracking(Expression<Func<T, bool>> where, IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).AsNoTracking().FirstOrDefault(where);
        }

        public virtual Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(includes: includes).AsNoTracking().FirstOrDefaultAsync(where);
        }

        public virtual T FindAsNoTracking(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).AsNoTracking().FirstOrDefault(where);
        }

        public virtual Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(includes: includes).AsNoTracking().FirstOrDefaultAsync(where);
        }

        public virtual IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes).AsNoTracking();
        }

        public virtual IQueryable<T> ListAsNoTracking(
            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes,
            Expression<Func<T, bool>> where = null,
            string SortField = null,
            string SortType = null,
            int? page = null,
            int? PageSize = null
            )
        {
            return CurrentSet(includes: includes, where: where, SortField: SortField, SortType: SortType, page: page, PageSize: PageSize).AsNoTracking();
        }

        public virtual IQueryable<T> ListAsNoTracking(
            Expression<Func<T, bool>> where,
            IPagination pagination,
            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes
            )
        {
            return ListAsNoTracking(includes: includes, where: where, SortField: pagination.SortField, SortType: pagination.SortType, page: pagination.PageIndex, PageSize: pagination.PageSize);
        }

        public virtual IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            params Expression<Func<T, object>>[] includes)
        {
            return CurrentSet(where, page, PageSize, SortField, SortType, includes).AsNoTracking();
        }

        public virtual IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination, IEnumerable<string> includes = null)
        {
            return ListAsNoTracking(where, pagination.PageIndex, pagination.PageSize, pagination.SortField, pagination.SortType, includes);
        }

        public virtual IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination, params Expression<Func<T, object>>[] includes)
        {
            return ListAsNoTracking(where, pagination.PageIndex, pagination.PageSize, pagination.SortField, pagination.SortType, includes);
        }

        public virtual PagedList<T> PagedListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination, params Expression<Func<T, object>>[] includes)
        {
            var total = _dataContext.DbContext.Set<T>().Count(where);

            var itens = ListAsNoTracking(where, pagination, includes);

            return new PagedList<T>(itens, total, pagination.PageSize);
        }
    }
}