using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

using Hlcpereira.Playmove.Domain.Contracts.DataContext;

namespace Hlcpereira.Playmove.Domain.Contracts.Repositories.Base
{
    public interface IRepositoryBase<T> where T: class
    { 
        IDataContext _dataContext { get; }
        
        protected IQueryable<T> CurrentSet(
            Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            IEnumerable<string> includes = null)
        {
            IQueryable<T> currentSet = _dataContext.DbContext.Set<T>();

            where ??= (x => true);

            if (includes != null)
            {
                currentSet = includes.Where(include => !string.IsNullOrEmpty(include))
                    .Aggregate(currentSet, (current, include) => current.Include(include));
            }

            currentSet = currentSet.Where(where);

            if (!string.IsNullOrEmpty(SortField) && !string.IsNullOrEmpty(SortType))
            {
                var order = string.Join(",",
                    SortField.Split(",")
                        .Select(x => x.Replace(" ", ""))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => $"{x} {SortType}")
                        .ToArray());
                currentSet = currentSet.OrderBy(order);
            }

            if (page != null && PageSize != null)
            {
                currentSet = currentSet
                    .Skip((page.Value - 1) * PageSize.Value)
                    .Take(PageSize.Value);
            }

            return currentSet;
        }

        protected IQueryable<T> CurrentSet(
            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes,
            Expression<Func<T, bool>> where = null,
            string SortField = null,
            string SortType = null,
            int? page = null,
            int? PageSize = null
            )
        {
            IQueryable<T> currentSet = _dataContext.DbContext.Set<T>();

            where ??= (x => true);

            if (includes != null && includes.Any())
                currentSet = includes.Aggregate(currentSet, (current, include) => include(current));

            currentSet = currentSet.Where(where);

            if (!string.IsNullOrEmpty(SortField) && !string.IsNullOrEmpty(SortType))
            {
                var order = string.Join(",",
                    SortField.Split(",")
                        .Select(x => x.Replace(" ", ""))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => $"{x} {SortType}")
                        .ToArray());
                currentSet = currentSet.OrderBy(order);
            }

            if (page != null && PageSize != null)
            {
                currentSet = currentSet
                    .Skip((page.Value - 1) * PageSize.Value)
                    .Take(PageSize.Value);
            }

            return currentSet;
        }
        
        protected IQueryable<T> CurrentSet(
            Expression<Func<T, bool>> where = null,
            int? page = null,
            int? PageSize = null,
            string SortField = null,
            string SortType = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> currentSet = _dataContext.DbContext.Set<T>();

            where ??= (x => true);

            if (includes != null && includes.Any())
            {
                currentSet = includes.Aggregate(currentSet, (current, include) => current.Include(include));
            }

            currentSet = currentSet.Where(where);

            if (!string.IsNullOrEmpty(SortField) && !string.IsNullOrEmpty(SortType))
            {
                var order = string.Join(",",
                    SortField.Split(",")
                        .Select(x => x.Replace(" ", ""))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => $"{x} {SortType}")
                        .ToArray());
                currentSet = currentSet.OrderBy(order);
            }

            if (page != null && PageSize != null)
            {
                currentSet = currentSet
                    .Skip((page.Value - 1) * PageSize.Value)
                    .Take(PageSize.Value);
            }

            return currentSet;
        }
    }
}