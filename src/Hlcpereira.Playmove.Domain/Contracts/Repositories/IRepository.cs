using Hlcpereira.Playmove.Domain.Contracts.Repositories.Base;

namespace Hlcpereira.Playmove.Domain.Contracts.Repositories
{
    public interface IRepository<T> : 
        ICrudRepository<T>,
        IQueryRepository<T>,
        IQueryAsNoTrackingRepository<T>
        where T : class
    {
    }
}